using TaskoMask.Application.Core.Helpers;
using FluentValidation.Results;
using MediatR;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Organizations.Commands.Models
{
    public abstract class OrganizationCommand : BaseCommand
    {
        public OrganizationCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }

    }
}
