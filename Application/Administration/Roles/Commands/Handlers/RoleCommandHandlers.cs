using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Administration.Roles.Commands.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Administration.Roles.Commands.Handlers
{
    public class RoleCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateRoleCommand, CommandResult>,
        IRequestHandler<UpdateRoleCommand, CommandResult>
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors


        public RoleCommandHandlers(IRoleRepository roleRepository, IDomainNotificationHandler notifications, IEncryptionService encryptionService, IInMemoryBus _inMemoryBus) : base(notifications, _inMemoryBus)
        {
            _roleRepository = roleRepository;
            _encryptionService = encryptionService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var existRole = await _roleRepository.ExistByNameAsync("", request.Name);
            if (existRole)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var role = new Role(name: request.Name, description: request.Description);
            if (!IsValid(role))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _roleRepository.CreateAsync(role);

            return new CommandResult(ApplicationMessages.Create_Success, role.Id.ToString());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var existRole = await _roleRepository.ExistByNameAsync(request.Id, request.Name);
            if (existRole)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var role = await _roleRepository.GetByIdAsync(request.Id);
            if (role == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Role);


            role.Update(request.Name, request.Description);
            if (!IsValid(role))
                return new CommandResult(ApplicationMessages.Update_Failed);

            await _roleRepository.UpdateAsync(role);

            return new CommandResult(ApplicationMessages.Update_Success, role.Id.ToString());
        }


        #endregion

    }
}
