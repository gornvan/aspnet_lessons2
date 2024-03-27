namespace FabricMarket_MVC.Startup.ConfigurationChecker
{
    public static class ConfigurationChecker
    {
        public static void ThrowIfConfigurationIsIncorrect(IConfiguration config)
        {
            var baseUrl = config.GetValue<string>("ApiBaseUrl");
            if (baseUrl == null)
            {
                throw new ConfigurationException("ApiBaseUrl is required, please add it as root-level field");
			}
		}
    }
}
