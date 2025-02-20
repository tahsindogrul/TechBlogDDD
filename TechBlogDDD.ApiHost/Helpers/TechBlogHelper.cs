using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechBlogDDD.Application.Contract.Login.Queries;

namespace TechBlogDDD.ApiHost.Helpers
{
    public class TechBlogHelper
    {
        internal static string GenerateToken(GetLoginQueryRequest user, List<string>? roles)
        {
            var expiration = DateTime.UtcNow.AddDays(7);
            var token = CreateJwtToken(
                CreateClaims(user, roles),
                CreateSigningCredentials(),
                expiration
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }



        private static JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
            new(
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtSettings")["Issuer"],
                new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtSettings")["Audience"],
                claims,
                expires:expiration,
                signingCredentials:credentials
                );


        private static List<Claim> CreateClaims(GetLoginQueryRequest user,List<string>? roles)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                       new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.FullName),
                        new Claim(ClaimTypes.SerialNumber,user.UserId.ToString())
                };
                if(roles != null && roles.Count > 0)
                {
                    foreach(var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }
                return claims;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                    throw;
            }
        }

        private static SigningCredentials CreateSigningCredentials()
        {
            var symmetricSecurityKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtSettings")["SymmetricSecurityKey"];

            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(symmetricSecurityKey)
                ), 
                SecurityAlgorithms.HmacSha256
                );
        }
    }
}
