namespace FabricMarket_MVC.Startup.ConfigurationChecker
{
	public class ConfigurationException : Exception
	{
		public ConfigurationException(string? message) : base(message)
		{
		}
	}
}
