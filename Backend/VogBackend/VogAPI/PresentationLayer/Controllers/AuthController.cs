using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogicLayer.Contracts.Requests;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace PresentationLayer.Controllers
{
  [ApiController]
  [Route("/Auth")]
  public class AuthController : ControllerBase
  {
    private readonly AuthService _authService;
    private readonly IConfiguration _configuration;

    public AuthController(AuthService authService, IConfiguration configuration)
    {
      _authService = authService;
      _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
      var user = await _authService.ValidateUserAsync(loginRequest.UserName, loginRequest.Password);
      if (user == null)
      {
        return Unauthorized();
      }
      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim("username", user.Username),
        new Claim(ClaimTypes.Role, user.Role),
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(2),
        signingCredentials: creds
      );

      return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    // Admin-only endpoint
    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult Admin()
    {
      return Ok("This is the Admin Page");
    }

    // Authenticated users only
    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
      var username = User.FindFirst("username")?.Value;
      return Ok($"Hello {username}");
    }

    // Public endpoint
    [HttpGet("public")]
    public IActionResult Public()
    {
      return Ok("Anyone can access this");
    }
  }
}
