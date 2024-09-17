using Conduit.Application.Entities;
using Conduit.Infrastructure.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Infrastructure.Utils
{
    public  class AuthService
    {
        public string GenerateToken(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthSettings.PrivateKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddSeconds(15), // only?
                SigningCredentials = credentials,
            };

            var token = handler.CreateJwtSecurityToken(tokenDescriptor);
            return handler.WriteToken(token);

        }
        private static ClaimsIdentity GenerateClaims(User user) // could add roles, but not needed
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            return claims;
        }
    }
    /*  
  "username": "string",
  "password": "string",
  "email": "string",
  "id": 0,
  "bio": "string",
  "image": "string",
  "createdAt": "2024-09-10T10:48:18.868Z",
  "articles": [],
  "following": [],
  "favorites": []
     */
}
