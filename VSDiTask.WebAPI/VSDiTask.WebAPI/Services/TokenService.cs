using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VSDiTask.Core.Settings;
using VSDiTask.Users.Models;

namespace VSDiTask.WebAPI.Services
{
    public interface ITokenService
    {
        string GetToken(UserToken user, int expiryMinutes = 0);
    }

    public class TokenService : ITokenService
    {
        private readonly TokenSetting _tokenSetting;
        public TokenService(IOptions<TokenSetting> tokenOption)
        {
            _tokenSetting = tokenOption.Value;
        }
        public string GetToken(UserToken user, int expiryMinutes = 0)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            if (expiryMinutes == 0)
            {
                expiryMinutes = _tokenSetting.ExpiryMinutes;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.SecurityKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
