using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ApiRestaurante.Interfaces
{
    public class AutenticacionJWT : IAutenticacionJWT
    {
        private string key;

        public AutenticacionJWT(string key)
        {
            this.key = key;
        }
        public object Autenticacion()
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "usuario_libre")
                };
            var token = new JwtSecurityToken(
                   expires: DateTime.Now.AddHours(1),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                   );
            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };
        }
    }
}
