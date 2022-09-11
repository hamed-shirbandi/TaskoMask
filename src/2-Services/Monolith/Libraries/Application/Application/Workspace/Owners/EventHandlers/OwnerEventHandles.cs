using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Owners;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class OwnerEventHandles : 
        INotificationHandler<OwnerRegisteredEvent>,
        INotificationHandler<OwnerProfileUpdatedEvent>
    {
        #region Fields

        private readonly IOwnerRepository _ownerRepository;

        #endregion

        #region Ctors

        public OwnerEventHandles(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OwnerRegisteredEvent createdOwner, CancellationToken cancellationToken)
        {
            var owner = new Owner(createdOwner.Id)
            {
                DisplayName= createdOwner.DisplayName,
                Email= createdOwner.Email,
            };
           await _ownerRepository.CreateAsync(owner);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OwnerProfileUpdatedEvent updatedOwner, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(updatedOwner.Id);

            owner.DisplayName = updatedOwner.DisplayName;
            owner.Email = updatedOwner.Email;

            owner.SetAsUpdated();

            await _ownerRepository.UpdateAsync(owner);

        }



        #endregion
    }
}
