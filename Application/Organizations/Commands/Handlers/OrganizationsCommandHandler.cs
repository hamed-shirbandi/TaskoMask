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
    public class OrganizationsCommandHandler : BaseCommandHandler, 
        IRequestHandler<CreateOrganizationCommand, Result<CommandResult>>,
        IRequestHandler<UpdateOrganizationCommand, Result<CommandResult>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrganizationsCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, IMediator mediator) : base(mediator)
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




        public async Task<Result<CommandResult>> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorsAsync(request);
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }


            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            var exist = await _organizationRepository.ExistByNameAsync(organization.Id, request.Name);
            if (exist)
            {
                await _mediator.Publish(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return Result.Failure<CommandResult>(ApplicationMessages.Update_Failed);
            }

            organization.SetName(request.Name);
            organization.SetDescription(request.Description);

            await _organizationRepository.UpdateAsync(organization);
            return Result.Success(new CommandResult(organization.Id, ApplicationMessages.Update_Success));

        }

    }
}
