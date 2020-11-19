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
    public class CreateOrganizationCommandHandler : CommandHandler,IRequestHandler<CreateOrganizationCommand, Result<CommandResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, IMediator mediator):base(mediator)
        {
            _organizationRepository = organizationRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Result<CommandResult>> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Create_Failed);
            }

            //TODO check if name is exist and add error to DomainNotification

            var organization = _mapper.Map<Organization>(request); 
            await _organizationRepository.CreateAsync(organization);

            return Result.Success(new CommandResult(organization.Id,ApplicationMessages.Create_Success));
        }
    }
}
