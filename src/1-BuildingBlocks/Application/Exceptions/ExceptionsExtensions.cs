using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace TaskoMask.BuildingBlocks.Application.Exceptions
{
    public static class ExceptionsExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddApplicationExceptionsHandler(this IServiceCollection services)
        {
           return  services.AddScoped(typeof(IRequestExceptionHandler<,,>), typeof(ApplicationExceptionsHandler<,,>));
        }
    }
}
