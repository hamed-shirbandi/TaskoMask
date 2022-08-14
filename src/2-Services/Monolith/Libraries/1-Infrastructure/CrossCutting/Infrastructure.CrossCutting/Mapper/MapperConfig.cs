using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Services.Monolith.Application.Mapper.Profiles;

namespace TaskoMask.Services.Monolith.Application.Mapper
{

    /// <summary>
    /// 
    /// </summary>
    public static class MapperConfig
    {


        /// <summary>
        /// 
        /// </summary>
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //this will find all profiles in this layer (Infrastructure.CrossCutting)
            services.AddAutoMapper(typeof(WorkspaceMappingProfile));
        }
    }
}
