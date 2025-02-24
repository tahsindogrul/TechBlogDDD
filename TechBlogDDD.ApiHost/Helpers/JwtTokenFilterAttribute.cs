using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechBlogDDD.Domain.Shared.Globals;

namespace TechBlogDDD.ApiHost.Helpers
{
    public class JwtTokenFilterAttribute:ActionFilterAttribute
    {
        private readonly string _secretKey;

        public JwtTokenFilterAttribute( )
        {
           var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _secretKey = configuration["Jwt:SecretKey"] ?? throw new Exception("JWT SecretKey not found!");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if(!ValidateToken(token,out ClaimsPrincipal principal))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var userId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber)?.Value;
            UserSettings.UserId = Convert.ToInt32(userId);

            context.HttpContext.Items["UserId"]=userId;

            context.HttpContext.User = principal;

            base.OnActionExecuting(context);
        }

        private bool ValidateToken(string token,out ClaimsPrincipal principal)
        {
            principal = null;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_secretKey);
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return validatedToken != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
