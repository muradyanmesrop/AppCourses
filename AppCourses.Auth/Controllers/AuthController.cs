using AppCourses.Auth.Options;
using AppCourses.Core.Db;
using AppCourses.Core.Db.Entities;
using AppCourses.Core.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AppCourses.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IOptions<AuthOptions>? _authOptions;
        public AuthController(AppDbContext db, IOptions<AuthOptions> options)
        {
            _db = db;
            _authOptions = options;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var user = Authenticate(loginModel);
            if (user != null)
            {
                var token = GenerateJWT(user);
                return Ok(new { access_token = token });
            }
            return Unauthorized();
        }

        private User Authenticate(LoginModel loginModel)
        {
            User user = _db.Users.Where(u => u.Email == loginModel.Email).FirstOrDefault();
            if (user != null && BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                return user;
            }
            return null;
        }
        private string GenerateJWT(User user)
        {
            var authParams = _authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim("Roles", user.Role.ToString() )
            };
            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime.Value), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
