namespace Webshop.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}