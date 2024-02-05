namespace FabricMarket_TestWebApi.Contracts.Exceptions
{
    public class DbConnectionException : Exception
    {
        public DbConnectionException(string? message) : base(message)
        {
        }

        public DbConnectionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
