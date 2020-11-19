using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Organizations
{
    public abstract class OrganizationCommand : Command
    {
        public OrganizationCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }

    }
}
