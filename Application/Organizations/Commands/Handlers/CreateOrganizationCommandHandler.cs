using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class CreateOrganizationCommandHandler : BaseCommandHandler, IRequestHandler<CreateOrganizationCommand, Result<CommandResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _organizationRepository = organizationRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Result<CommandResult>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorsAsync(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            var organization = _mapper.Map<Organization>(request);

            var exist = await _organizationRepository.ExistByNameAsync(organization.Id,organization.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            await _organizationRepository.CreateAsync(organization);

            return Result.Success(new CommandResult(organization.Id, ApplicationMessages.Create_Success));
        }
    }
}
