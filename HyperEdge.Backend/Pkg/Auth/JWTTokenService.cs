using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace HyperEdge.Backend.Auth
{
    public class JwtTokenService
    {
        private readonly SymmetricSecurityKey _securityKey;

        public JwtTokenService(IOptions<JwtTokenServiceOptions> jwtTokenServiceOptions)
        {
            _securityKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtTokenServiceOptions.Value.Secret));
        }

        public (string Token, DateTime Expires) CreateToken(string userId)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var expires = DateTime.UtcNow.AddSeconds(10);
            var token = jwtTokenHandler.CreateEncodedJwt(new SecurityTokenDescriptor()
            {
                SigningCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                }),
                Expires = expires,
            });

            return (token, expires);
        }
    }
}
