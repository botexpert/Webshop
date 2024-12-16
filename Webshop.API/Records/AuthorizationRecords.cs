namespace Webshop.API.Models
{
    /// <summary>
    /// Represents the data required to register a new user.
    /// </summary>
    public record RegisterUserRequest(string Username, string Password, string Role = "User");

    /// <summary>
    /// Represents the data required to log in a user.
    /// </summary>
    public record LoginUserRequest(string Username, string Password);

    /// <summary>
    /// Represents the data returned after a successful login, including the JWT token.
    /// </summary>
    public record LoginResponse(string Token);
}