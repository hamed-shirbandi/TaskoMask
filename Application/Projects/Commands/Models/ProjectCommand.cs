using CSharpFunctionalExtensions;
using MediatR;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Projects
{
    public abstract class ProjectCommand : Command
    {
        public ProjectCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string OrganizationId { get; protected set; }
    }
}
