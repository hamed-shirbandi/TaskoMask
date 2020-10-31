using CSharpFunctionalExtensions;
using MediatR;

namespace TaskoMask.Application.Commands.Models.Organizations
{
    public abstract class OrganizationCommand : IRequest<Result>
    {
        public OrganizationCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string UserId { get; protected set; }
    }
}
