using Microsoft.Extensions.Configuration;

namespace TaskoMask.Services.Monolith.Application.Mapper
{


    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtensions
    {


        /// <summary>
        /// 
        /// </summary>
        public static string AddStaticSiteUrl( this string url, IConfiguration _configuration)
        {
            return string.IsNullOrEmpty(url) ? "" : _configuration["Url:StaticServer"] + url;
        }
    }
}
