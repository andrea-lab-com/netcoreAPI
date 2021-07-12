using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Web.Api.Core.Dto;
using Web.Api.Core.Interfaces.Services;

namespace Web.Api.Infrastructure.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<Token> GenerateEncodedToken(string id, string userName)
        {
            var identity = GenerateClaimsIdentity(id, userName);


//            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var encodedJwt = GenerateToken(id, userName);

            return new Token(identity.Claims.Single(c => c.Type == "id").Value, encodedJwt);
        }

        public string GenerateToken(string id, string userName)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, $"{id}"),
                new Claim(ClaimTypes.Name, userName),
            };

            var keygen = Environment.GetEnvironmentVariable("SECURITY_KEY");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keygen));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddDays(1);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaimsIdentity(string id, string userName)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Id, id),
                new Claim(Helpers.Constants.Strings.JwtClaimIdentifiers.Rol, Helpers.Constants.Strings.JwtClaims.ApiAccess)
            });
        }

    }
}
