using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Workspace.Organizations.Data;
using TaskoMask.Domain.Workspace.Organizations.Builders;
using TaskoMask.Domain.Workspace.Organizations.ValueObjects;
using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Domain.Workspace.Organizations.Services;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class OrganizationCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateOrganizationCommand, CommandResult>,
        IRequestHandler<UpdateOrganizationCommand, CommandResult>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOrganizationValidatorService _organizationValidatorService;

        #endregion

        #region Ctors

        public OrganizationCommandHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus, IOrganizationValidatorService organizationValidatorService) : base(notifications, inMemoryBus)
        {
            _organizationRepository = organizationRepository;
            _organizationValidatorService = organizationValidatorService;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            //to show how to use builder to create a domain object. It can be useful when the object has many parameters
            var organization = OrganizationBuilder.Init()
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithOwnerMemberId(request.OwnerMemberId)
                .WithValidator(_organizationValidatorService)
                .Build();

            await _organizationRepository.CreateAsync(organization);

            //TODO publish domain events

            return new CommandResult(ApplicationMessages.Create_Success, organization.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Organization);

            organization.UpdateOrganization(request.Name, request.Description, _organizationValidatorService);

            await _organizationRepository.UpdateAsync(organization);

            //TODO publish domain events

            return new CommandResult(ApplicationMessages.Update_Success, organization.Id);
        }


        #endregion

    }
}
