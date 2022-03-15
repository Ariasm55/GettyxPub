using Getty.Core.Entities;
using Getty.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GettyX.Api.Controllers
{
    public class TokenController : Controller
    {
        
        private readonly IConfiguration _configuration;

        public TokenController( IConfiguration configuration)
        {
          
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(UsrUser user)
        {
            if (IsValidUser(user))
            {

                var token = GenerateToken();

                return Ok(new { token });

            }

            return NotFound();
        }

        private bool IsValidUser(UsrUser user)
        {
            return true;
        }

        private string GenerateToken()
        {
            //Header
            var symmetricsecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricsecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Cesar Carcamo"),
                new Claim(ClaimTypes.Email, "Cesar.Carcamo@collectivesolution.net"),
                new Claim(ClaimTypes.Role, "Administrador"),

            };

            //payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            //crear token
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken( token);
        }


    }
}
