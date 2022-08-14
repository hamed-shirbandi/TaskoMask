using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Web.Extensions;
using TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.Models;

namespace TaskoMask.BuildingBlocks.Web.MVC.Services.Authentication.JwtAuthentication
{
    public class JwtAuthenticationService :  IJwtAuthenticationService
    {
        #region Fields

        private readonly JwtAuthenticationOptions _options;

        #endregion

        #region Ctor

        public JwtAuthenticationService(IOptions<JwtAuthenticationOptions> options) 
        {
            _options = options != null ? options.Value : throw new ArgumentNullException(nameof(options));
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public  string GenerateJwtToken(AuthenticatedUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //create claims for user
            claims.AddList(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_options.ExpireDays));

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        #endregion

        #region Private Methods



        #endregion




    }
}
