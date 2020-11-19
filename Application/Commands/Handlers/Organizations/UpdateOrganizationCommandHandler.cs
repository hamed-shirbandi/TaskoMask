using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Organizations;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class UpdateOrganizationCommandHandler : CommandHandler, IRequestHandler<UpdateOrganizationCommand, Result<string>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMediator _mediator;

        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMediator mediator) : base(mediator)
        {
            _organizationRepository = organizationRepository;
            _mediator = mediator;
        }

        public async Task<Result<string>> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<string>(ApplicationMessages.Update_Failed);
            }

            //TODO check if name is exist and add error to DomainNotification

            var organization = await _organizationRepository.GetByIdAsync(request.Id);

            organization.SetName(request.Name);
            organization.SetDescription(request.Description);

            await _organizationRepository.UpdateAsync(organization);
            return Result.Success(ApplicationMessages.Update_Success);
        }
    }
}
