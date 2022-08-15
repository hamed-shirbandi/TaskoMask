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
        public static IServiceCollection AddValidationBehaviour(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddEventStoringBehavior(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<INotificationHandler<IDomainEvent>, EventStoringBehavior>();

            return services;
        }


        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddCachingBehavior(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddEasyCaching(option=>option.UseInMemory());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            return services;
        }



        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddApplicationBehaviors(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddValidationBehaviour();
            services.AddCachingBehavior();
            services.AddEventStoringBehavior();

            return services;
        }
    }
}
