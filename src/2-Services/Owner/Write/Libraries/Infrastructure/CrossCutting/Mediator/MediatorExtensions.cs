using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;

namespace TaskoMask.Services.Owner.Infrastructure.CrossCutting.Mediator
{
    public static class MediatorExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            //Load all commands and queries ...
           // services.AddMediatR(typeof(UserLoginUseCase));

            //Load all fluent validation to use in ValidationBehaviour
           // services.AddValidatorsFromAssembly(typeof(UserLoginValidation<>).Assembly);

            return services;
        }
    }
}
