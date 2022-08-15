using System.Reflection;
using System.Security.Claims;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Web.Extensions
{
    public static class ClaimExtensions
    {

        public static void AddList(this List<Claim> claims, AuthenticatedUserModel user)
        {
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            //Add user prop by reflection. it helps when AuthenticatedUser changed
            var properties = new List<PropertyInfo>(user.GetType().GetProperties());
            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(user, property.GetIndexParameters());
                string name = property.Name;
                string value = propValue != null ? propValue.ToString() : "";
                claims.Add(new Claim(name, value));
            }
        }
    }
}
