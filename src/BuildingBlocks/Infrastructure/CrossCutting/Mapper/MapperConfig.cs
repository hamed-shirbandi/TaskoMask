﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.Application.Mapper.Profiles;

namespace TaskoMask.Application.Mapper
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
