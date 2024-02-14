namespace FabricMarket_BLL.Contracts.SystemSettings
{
    internal class SettingsUpdateException : Exception
    {
        public SettingsUpdateException(string? message) : base(message)
        {
        }
    }
}
