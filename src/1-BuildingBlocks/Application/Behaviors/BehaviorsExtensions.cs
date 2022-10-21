using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Application.Behaviors
{
    public static class BehaviorsExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static void AddValidationBehaviour(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddEventStoringBehavior(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainEvent>, EventStoringBehavior>();
        }


        /// <summary>
        /// 
        /// </summary>
        public static void AddCachingBehavior(this IServiceCollection services)
        {
            services.AddEasyCaching(option=>option.UseInMemory());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }



        /// <summary>
        /// 
        /// </summary>
        public static void AddApplicationBehaviors(this IServiceCollection services)
        {
            services.AddValidationBehaviour();
            services.AddCachingBehavior();
            services.AddEventStoringBehavior();
        }
    }
}
