using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Team.Organizations.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Team.Entities.Organizations.ValueObjects;
using TaskoMask.Domain.Team.Entities.Organizations;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class OrganizationCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateOrganizationCommand, CommandResult>,
        IRequestHandler<UpdateOrganizationCommand, CommandResult>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;


        #endregion

        #region Ctors

        public OrganizationCommandHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            //TODO chck foreign key for all other commands
            //TODO move this type of validations to domain
            //TODO check by repository
            var existOwnerMemberId = true;
            if (!existOwnerMemberId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey, nameof(request.OwnerMemberId)));

            var exist = await _organizationRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var organization = OrganizationBuilder.Init()
                .WithName(request.Name)
                .WithDescription(request.Description)
                .WithOwnerMemberId(request.OwnerMemberId)
                .Build();

            if (!IsValid(organization))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _organizationRepository.CreateAsync(organization);

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


            var exist = await _organizationRepository.ExistByNameAsync(organization.Id, request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            organization.Update(
                OrganizationName.Create(request.Name),
                OrganizationDescription.Create(request.Description)
                );


            if (!IsValid(organization))
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _organizationRepository.UpdateAsync(organization);
            return new CommandResult(ApplicationMessages.Update_Success, organization.Id);

        }


        #endregion

    }
}
