using FabricMarket_BLL.Contracts;
using FabricMarket_TestWebApi.ConfigurationSections;
using System.Data;

namespace FabricMarket_TestWebApi
{
    public static class CorsConfigurer
    {
        public const string StrictCorsPolicyName = "MyStrictCorsPolicy";
        public const string RelaxedCorsPolicyName = "AllowAll";

        public static void Configure(WebApplicationBuilder builder)
        {
            var corsConfig = builder.Configuration.GetSection(nameof(CorsConfiguration)).Get<CorsConfiguration>();
            if(corsConfig == null) {
                throw new Exception("No CORS config section found!");
            }

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(StrictCorsPolicyName,
                                    policy =>
                                    {
                                        policy
                                            .WithOrigins(corsConfig.AllowedOrigins.ToArray())
                                            .WithHeaders(corsConfig.AllowedHeaders.ToArray())
                                            .WithMethods(corsConfig.AllowedMethods.ToArray())
                                            .AllowCredentials();
                                    });
            });


            // relaxed policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(RelaxedCorsPolicyName, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();

                    // policy.AllowAnyOrigin(); // does not allow to have AllowCredentials()
                    policy.SetIsOriginAllowed(hostName => true);

                    policy.AllowCredentials();
                });
            });
        }
    }
}
