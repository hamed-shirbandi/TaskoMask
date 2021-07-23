using Microsoft.Extensions.Configuration;

namespace TaskoMask.Application.Mapper
{
    public static class MapperExtensions
    {
        public static string AddStaticSiteUrl( this string url, IConfiguration _configuration)
        {
            return string.IsNullOrEmpty(url) ? "" : _configuration["Url:Static.Domain"] + url;
        }
    }
}
