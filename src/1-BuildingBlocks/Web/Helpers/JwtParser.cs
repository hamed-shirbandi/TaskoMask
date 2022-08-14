using System.Security.Claims;
using System.Text.Json;
using TaskoMask.Services.Monolith.Domain.Share.Models;

namespace TaskoMask.BuildingBlocks.Web.Helpers
{
    /// <summary>
    /// From the Steve Sanderson’s Mission Control project:
    /// https://github.com/SteveSandersonMS/presentation-2019-06-NDCOslo/blob/master/demos/MissionControl/MissionControl.Client/Util/ServiceExtensions.cs
    /// </summary>
    public static class JwtParser
    {


        public static AuthenticatedUser ParseAuthenticatedUserModelFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];

            var jsonBytes = ParseBase64WithoutPadding(payload);

            return JsonSerializer.Deserialize<AuthenticatedUser>(jsonBytes);
        }



        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];

            var jsonBytes = ParseBase64WithoutPadding(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}