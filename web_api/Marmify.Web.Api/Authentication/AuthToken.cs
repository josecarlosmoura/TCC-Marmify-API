using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marmify.Web.Api.Authentication
{
    public class AuthToken
    {
        public string GemerateToken(SigningConfigurations signingConfigurations, 
            TokenConfigurations tokenConfigurations,
            ClaimsIdentity identity, DateTime creationDate, DateTime expirationDate)
        {
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer.FirstOrDefault(),
                Audience = tokenConfigurations.Audience.FirstOrDefault(),
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);

            return token;
        }
    }
}
