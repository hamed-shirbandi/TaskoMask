using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.WriteModel.Authorization.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Events.Owners;

namespace TaskoMask.Application.Workspace.Owners.EventHandlers
{
    public class OwnerEventHandles : 
        INotificationHandler<OwnerCreatedEvent>,
        INotificationHandler<OwnerUpdatedEvent>,
        INotificationHandler<OwnerDeletedEvent>,
        INotificationHandler<OwnerRecycledEvent>
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
        public async System.Threading.Tasks.Task Handle(OwnerCreatedEvent createdOwner, CancellationToken cancellationToken)
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
        public async System.Threading.Tasks.Task Handle(OwnerUpdatedEvent updatedOwner, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(updatedOwner.Id);
            var user = await _userRepository.GetByIdAsync(updatedOwner.Id);

            owner.DisplayName = updatedOwner.DisplayName;
            owner.Email = updatedOwner.Email;
            owner.UserName = user.UserName;

            owner.SetAsUpdated();

            await _ownerRepository.UpdateAsync(owner);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OwnerDeletedEvent deletedOwner, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(deletedOwner.Id);
            owner.SetAsDeleteed();
            await _ownerRepository.UpdateAsync(owner);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(OwnerRecycledEvent recycledOwner, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(recycledOwner.Id);
            owner.SetAsRecycled();
            await _ownerRepository.UpdateAsync(owner);
        }

        #endregion






    }
}
