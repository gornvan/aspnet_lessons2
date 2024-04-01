namespace FabricMarket_TestWebApi.ConfigurationSections
{
    public class CorsConfiguration
    {
        public List<string> AllowedOrigins { get; set; } = new List<string>();
        public List<string> AllowedMethods { get; set; } = new List<string>();
        public List<string> AllowedHeaders { get; set; } = new List<string>();
    }
}

