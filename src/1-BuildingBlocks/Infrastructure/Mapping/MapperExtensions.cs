using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskoMask.BuildingBlocks.Infrastructure.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //this will find all profiles in this layer
            services.AddAutoMapper(profileAssemblyMarkerTypes);
            services.AddAutoMapper(typeof(CommonMappingProfile));
        }


    }
}
