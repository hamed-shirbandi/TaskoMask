using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Domain.DomainModel.Authorization.Data;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Events.Owners;

namespace TaskoMask.Application.Workspace.Owners.EventHandlers
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
        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctors

        public OwnerEventHandles(IOwnerRepository ownerRepository, IUserRepository userRepository)
        {
            _ownerRepository = ownerRepository;
            _userRepository = userRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OwnerRegisteredEvent createdOwner, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(createdOwner.Id);

            var owner = new Owner(createdOwner.Id)
            {
                DisplayName= createdOwner.DisplayName,
                Email= createdOwner.Email,
                UserName= user.UserName,
                IsActive= user.IsActive,
            };
           await _ownerRepository.CreateAsync(owner);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OwnerProfileUpdatedEvent updatedOwner, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(updatedOwner.Id);
            var user = await _userRepository.GetByIdAsync(updatedOwner.Id);

            owner.DisplayName = updatedOwner.DisplayName;
            owner.Email = updatedOwner.Email;
            owner.UserName = user.UserName;

            owner.SetAsUpdated();

            await _ownerRepository.UpdateAsync(owner);

        }



        #endregion
    }
}
