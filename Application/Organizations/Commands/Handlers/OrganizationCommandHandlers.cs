using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Organizations.Commands.Validations;


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

        public OrganizationCommandHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications) : base(notifications)
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
            if (!IsValid(request, new CreateOrganizationCommandValidation()))
                return new CommandResult(ApplicationMessages.Create_Failed);


            //TODO chck foreign key for all other commands
            //TODO move this type of validations to domain
            //TODO check by repository
            var existUserId = true;
            if (!existUserId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey, nameof(request.UserId)));



            var exist = await _organizationRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var organization = new Organization(name: request.Name, description: request.Description, userId: request.UserId);
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
            if (!IsValid(request, new UpdateOrganizationCommandValidation()))
                return new CommandResult(ApplicationMessages.Create_Failed);

            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Organization);


            var exist = await _organizationRepository.ExistByNameAsync(organization.Id, request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            organization.Update(request.Name, request.Description);


            if (!IsValid(organization))
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _organizationRepository.UpdateAsync(organization);
            return new CommandResult(ApplicationMessages.Update_Success, organization.Id);

        }


        #endregion

    }
}
