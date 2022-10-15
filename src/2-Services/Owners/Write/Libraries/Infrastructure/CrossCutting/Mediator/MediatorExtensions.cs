using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;

namespace TaskoMask.Services.Owners.Write.Infrastructure.CrossCutting.Mediator
{
    public static class MediatorExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            //Load all commands and queries ...
            services.AddMediatR(typeof(RegiserOwnerUseCase));

            //Load all fluent validation to use in ValidationBehaviour
            services.AddValidatorsFromAssembly(typeof(RegiserOwnerValidation<>).Assembly);

            return services;
        }
    }
}
