namespace lesson5_Chain_Of_Responsibility
{
    public class ClientIsLocalhostException : Exception
    {
        public ClientIsLocalhostException() : base()
        {
        }

        public ClientIsLocalhostException(string? message) : base(message)
        {
        }

        public ClientIsLocalhostException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
