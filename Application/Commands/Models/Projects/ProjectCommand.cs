using CSharpFunctionalExtensions;
using MediatR;

namespace TaskoMask.Application.Commands.Models.Projects
{
    public abstract class ProjectCommand : IRequest<Result>
    {
        public ProjectCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string OrganizationId { get; protected set; }
    }
}
