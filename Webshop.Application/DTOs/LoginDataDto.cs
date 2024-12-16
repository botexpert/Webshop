namespace Webshop.Application.DTOs{
    public class LoginDataDto{
        public string Username { get;}
        public string Password { get;}

        public LoginDataDto(string username,string password)
        {
            Username = username;
            Password = password;
        }
    }
}