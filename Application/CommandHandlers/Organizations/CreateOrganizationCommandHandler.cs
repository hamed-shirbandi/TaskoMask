using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Organizations;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.CommandHandlers.Organizations
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, Result>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }


        public async Task<Result> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            //TODO request validation

            var organization = new Organization(request.Name,request.Description,request.UserId);
            await _organizationRepository.CreateAsync(organization);
            return Result.Success();
        }
    }
}
