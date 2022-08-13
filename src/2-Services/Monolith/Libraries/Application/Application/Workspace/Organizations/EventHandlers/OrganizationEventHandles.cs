using MediatR;
using System.Threading;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Events.Organizations;

namespace TaskoMask.Application.Workspace.Organizations.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class OrganizationEventHandles : 
        INotificationHandler<OrganizationAddedEvent>,
        INotificationHandler<OrganizationUpdatedEvent>,
        INotificationHandler<OrganizationDeletedEvent>
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
        public async System.Threading.Tasks.Task Handle(OrganizationAddedEvent addedOrganization, CancellationToken cancellationToken)
        {
            var organization = new Organization(addedOrganization.Id)
            {
                Name= addedOrganization.Name,
                Description= addedOrganization.Description,
                OwnerId= addedOrganization.OwnerId,
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
            await _organizationRepository.DeleteAsync(deletedOrganization.Id);
        }


        #endregion

    }
}
