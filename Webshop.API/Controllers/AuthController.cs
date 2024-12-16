using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Webshop.API.Models;
using Webshop.Application.DTOs;
using Webshop.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILoginService _loginService;

    public AuthController(IConfiguration configuration, ILoginService loginService)
    {
        _configuration = configuration;
        _loginService = loginService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequest request)
    {
        try
        {
            var role = await _loginService.LoginAsync(new LoginDataDto(request.Username, request.Password));
            if (!String.IsNullOrEmpty(role))
            {
                var token = GenerateJwtToken(request.Username, role);
                return Ok(new LoginResponse(token));
            }
        }
        catch (Exception)
        {
            //TODO: Log exception ex.message

            return Unauthorized();
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        var account = new AccountDto
        {
            Username = request.Username,
            Password = request.Password,
            Role = request.Role ?? "User"
        };

        try
        {
            var role = await _loginService.CreateAccountAsync(account);
            return Ok($"{role} registered successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    private string GenerateJwtToken(string username, string Role)
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, Role)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


