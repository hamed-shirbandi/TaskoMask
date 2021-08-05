using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Organizations.Commands.Validations;
using TaskoMask.Application.Core.Extensions;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class OrganizationsCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateOrganizationCommand, CommandResult>,
        IRequestHandler<UpdateOrganizationCommand, CommandResult>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public OrganizationsCommandHandlers(IOrganizationRepository organizationRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }


        public async Task<CommandResult> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var existUserId = true;
            if (!existUserId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey, nameof(request.UserId)));



            var exist = await _organizationRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var organization = _mapper.Map<Organization>(request);

            await _organizationRepository.CreateAsync(organization);

            return new CommandResult(ApplicationMessages.Create_Success, organization.Id);

        }




        public async Task<CommandResult> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Organization);



            var exist = await _organizationRepository.ExistByNameAsync(organization.Id, request.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            organization.SetName(request.Name);
            organization.SetDescription(request.Description);

            await _organizationRepository.UpdateAsync(organization);
            return new CommandResult(ApplicationMessages.Update_Success, organization.Id);

        }

    }
}
