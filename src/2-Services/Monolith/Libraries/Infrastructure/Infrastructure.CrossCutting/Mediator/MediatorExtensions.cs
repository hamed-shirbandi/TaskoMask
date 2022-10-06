using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Validations;
using FluentValidation;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.BuildingBlocks.Application.Behaviors;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Handlers;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mediator
{
    public static class MediatorExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            //Load all commands and queries ...
            services.AddMediatR(typeof(OwnerCommandHandlers));

            //Load all fluent validation to use in ValidationBehaviour
            services.AddValidatorsFromAssembly(typeof(AddOrganizationValidation).Assembly);

            return services;
        }
    }
}
