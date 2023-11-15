using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ejercicio2.seguridadToken
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public TokenService(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string?> GenerateToken(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            { 
                return null;
            }

            var issuerDato = _configuration["jwt:Issuer"];
            var audienceDato = _configuration["jwt:Audience"];
            var claveDato = _configuration["jwt:Key"];

            var claveseguridad = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveDato));
            var credenciales = new SigningCredentials(claveseguridad, SecurityAlgorithms.HmacSha256);

            
            // CLAIMS
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id), // Subject (ID del usuario)
            };

            // Obtener roles del usuario actual
            var roles = await _userManager.GetRolesAsync(user);

            // Agregar cada rol como una claim
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            //TOKEN
            var token = new JwtSecurityToken(
                issuer: issuerDato,
                audience: audienceDato,
                expires: DateTime.Now.AddMinutes(30),
                claims: claims,
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
