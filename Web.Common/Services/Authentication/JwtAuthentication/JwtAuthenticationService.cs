using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text;
using System.Reflection;
using TaskoMask.Web.Common.Services.Authentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TaskoMask.Application.Core.Extensions;

namespace TaskoMask.Web.Common.Services.Authentication.JwtAuthentication
{
    public class JwtAuthenticationService : IJwtAuthenticationService
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
        public  string GenerateJwtToken<T>(string userName,string id, T jwtModel)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, id)
            };


            var properties = new List<PropertyInfo>(jwtModel.GetType().GetProperties());

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(jwtModel, property.GetIndexParameters());

                string name = property.Name.ToString().ToLowerFirst();
                string value = propValue != null ? propValue.ToString() : "";
                claims.Add(new Claim(name, value));
            }


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
