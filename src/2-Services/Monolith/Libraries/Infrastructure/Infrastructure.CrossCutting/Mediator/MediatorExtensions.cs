using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Validations;
using FluentValidation;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mediator
{
    public static class MediatorExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services)
        {
            //Load all commands and queries ...
            services.AddMediatR(typeof(BoardBaseCommand));
            //Load all fluent validation to use in ValidationBehaviour
            services.AddValidatorsFromAssembly(typeof(AddOrganizationValidation).Assembly);

            return services;
        }
    }
}
