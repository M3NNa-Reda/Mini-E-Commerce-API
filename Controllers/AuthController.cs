using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Mini_E_Commerce_API.Data;
using Mini_E_Commerce_API.DTOs;
using Mini_E_Commerce_API.Helpers;
using Mini_E_Commerce_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mini_E_Commerce_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(JwtOptions jwtOptions,ApplicationDbContext context) :ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterUserDto register)
        {
            var existuser = context.Users.Any(x => x.FullName == register.FullName);
            if(existuser)
                return BadRequest("This Name already exists.");
            var user = new User
            {
                FullName = register.FullName,
                Email = register.Email,
                Password = register.Password,
                Role = "Customer"
            };
            context.Users.Add(user);
            context.SaveChanges();
            return Ok("Your register is success!");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUserDto login)
        {
            var user = context.Users
                .FirstOrDefault(x => x.FullName == login.Username && x.Password == login.Password);
            
            if (user == null)
                return Unauthorized("Invalid Username or Password.");
            var claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new(ClaimTypes.Name,user.FullName),
                new(ClaimTypes.Role,user.Role)
            };
            var TokenHandler = new JwtSecurityTokenHandler();
            var discriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Signingkey)),
                SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow.AddDays(jwtOptions.Lifetime),
                Subject =new ClaimsIdentity(claims)
            };
            var securityToken = TokenHandler.CreateToken(discriptor);
            var accesstoken  =TokenHandler.WriteToken(securityToken);
            return Ok(accesstoken);
        }

    }
}
