namespace lesson11_FabricMarket_DomainModel.Models.Identity
{
    public class User
    {
        public required string Name {get; set;}
        public required string Email {get; set;}
        public required UserRole Role {get; set;}
        public required string PasswordHash {get; set;}
        public required string PasswordSalt { get; set; }
    }
}
