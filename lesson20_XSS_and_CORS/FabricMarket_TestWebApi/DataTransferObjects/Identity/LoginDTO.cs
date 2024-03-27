namespace FabricMarket_TestWebApi.DataTransferObjects.Identity
{
    public class LoginDTO
    {
        public required string Email { get; set;}
        public required string Password { get; set; }
    }
}
