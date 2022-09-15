using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.Profiles;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper
{


    /// <summary>
    /// 
    /// </summary>
    public static class MapperExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //this will find all profiles in this layer (Infrastructure.CrossCutting)
            services.AddAutoMapper(typeof(WorkspaceMappingProfile));
        }


    }
}
