using FabricMarket_BLL.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FabricMarket_BLL
{
    internal struct InterfaceToImplementation
    {
        public Type Implementation;
        public Type Interface;
    }

    public static class FabricMarket_BLL_ModuleHead
    {
        public static void RegisterModule(IServiceCollection services)
        {
            var currentAssembly = Assembly.GetAssembly(typeof(FabricMarket_BLL_ModuleHead));

            var allTypesInThisAssembly = currentAssembly.GetTypes();

            var serviceTypes = allTypesInThisAssembly
                .Where(type =>
                    type.IsAssignableTo(typeof(IService))
                    && !type.IsInterface
                );

            var interfaceToImplementationMap = serviceTypes.Select(serviceType => {
                var implementation = serviceType;
                var @interface = serviceType.GetInterfaces()
                    .First(serviceInterface => serviceInterface != typeof(IService));

                return new InterfaceToImplementation
                {
                    Interface = @interface,
                    Implementation = implementation,
                };
            });

            foreach (var serviceToInterface in interfaceToImplementationMap)
            {
                services.AddTransient(serviceToInterface.Interface, serviceToInterface.Implementation);
            }
        }
    }
}
