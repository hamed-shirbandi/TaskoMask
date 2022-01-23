using MediatR;
using System.Threading;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Organizations;

namespace TaskoMask.Application.Workspace.Organizations.EventHandlers
{
    public class OrganizationEventHandles : 
        INotificationHandler<OrganizationCreatedEvent>,
        INotificationHandler<OrganizationUpdatedEvent>,
        INotificationHandler<OrganizationDeletedEvent>,
        INotificationHandler<OrganizationRecycledEvent>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctors

        public OrganizationEventHandles(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OrganizationCreatedEvent createdOrganization, CancellationToken cancellationToken)
        {
            var organization = new Organization(createdOrganization.Id)
            {
                Name= createdOrganization.Name,
                Description= createdOrganization.Description,
                OwnerId= createdOrganization.OwnerId,
            };
           await _organizationRepository.CreateAsync(organization);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OrganizationUpdatedEvent updatedOrganization, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(updatedOrganization.Id);

            organization.Name = updatedOrganization.Name;
            organization.Description = updatedOrganization.Description;

            organization.SetAsUpdated();

            await _organizationRepository.UpdateAsync(organization);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OrganizationDeletedEvent deletedOrganization, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(deletedOrganization.Id);
            organization.SetAsDeleteed();
            await _organizationRepository.UpdateAsync(organization);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OrganizationRecycledEvent recycledOrganization, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(recycledOrganization.Id);
            organization.SetAsRecycled();
            await _organizationRepository.UpdateAsync(organization);
        }

        #endregion






    }
}
