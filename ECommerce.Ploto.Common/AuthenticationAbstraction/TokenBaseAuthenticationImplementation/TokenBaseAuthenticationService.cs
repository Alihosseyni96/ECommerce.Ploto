using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.TokenBaseAuthenticationImplementation
{
    public class TokenBaseAuthenticationService : ITokenBaseAuthenticationService
    {
        private readonly TokenauthenticationOptions _options;

        public TokenBaseAuthenticationService(TokenauthenticationOptions options)
        {
            _options = options;
        }

        public string GenerateToken(params (string claimKey, string claimValue)[] addCleims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            foreach (var claim in addCleims)
            {
                claims.Add(new Claim(claim.claimKey, claim.claimValue));
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = _options.Expires,
                SigningCredentials = credentials,
                Issuer = _options.Issuer,
                Audience = _options.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.Audience,
                IssuerSigningKey = key
            };


            try
            {
                SecurityToken validatedToken;
                return tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
            }
            catch (System.Exception e)
            {
                throw new AuthenticationException();
            }
        }
    }
}
