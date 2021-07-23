using CSharpFunctionalExtensions;
using MediatR;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Projects.Commands.Models
{
    public abstract class ProjectCommand : BaseCommand
    {
        public ProjectCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string OrganizationId { get; protected set; }
    }
}
