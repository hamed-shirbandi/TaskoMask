
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper
{

    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //this will find all profiles in this layer
            services.AddAutoMapper(typeof(MappingProfile));
        }


    }
}
