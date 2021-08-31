using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Managers.Commands.Models;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Managers.Commands.Handlers
{
    public class ManagerCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateManagerCommand, CommandResult>,
        IRequestHandler<UpdateManagerCommand, CommandResult>
    {
        #region Fields

        private readonly IManagerRepository _managerRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors


        public ManagerCommandHandlers(IManagerRepository managerRepository, IDomainNotificationHandler notifications, IEncryptionService encryptionService, IInMemoryBus _inMemoryBus) : base(notifications, _inMemoryBus)
        {
            _managerRepository = managerRepository;
            _encryptionService = encryptionService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            var existManager = await _managerRepository.GetByUserNameAsync(request.Email);
            if (existManager != null)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var manager = new Manager(displayName: request.DisplayName, email: request.Email, userName: request.Email, password: request.Password, encryptionService: _encryptionService);
            if (!IsValid(manager))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await PublishDomainEventsAsync(manager.DomainEvents);

            await _managerRepository.CreateAsync(manager);

            return new CommandResult(ApplicationMessages.Create_Success, manager.Id.ToString());
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            var existManager = await _managerRepository.GetByUserNameAsync(request.Email);
            if (existManager != null && existManager.Id.ToString() != request.Id)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed);
            }

            var manager = await _managerRepository.GetByIdAsync(request.Id);
            if (manager == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Manager);


            manager.Update(request.DisplayName, request.Email, request.Email);
            if (!IsValid(manager))
                return new CommandResult(ApplicationMessages.Update_Failed);

            await _managerRepository.UpdateAsync(manager);

            return new CommandResult(ApplicationMessages.Update_Success, manager.Id.ToString());
        }


        #endregion

    }
}
