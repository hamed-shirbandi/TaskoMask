using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Administration.Operators.Commands.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Administration.Operators.Commands.Handlers
{
    public class OperatorCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateOperatorCommand, CommandResult>,
        IRequestHandler<UpdateOperatorCommand, CommandResult>
    {
        #region Fields

        private readonly IOperatorRepository _operatorRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors


        public OperatorCommandHandlers(IOperatorRepository operatorRepository, IDomainNotificationHandler notifications, IEncryptionService encryptionService, IInMemoryBus _inMemoryBus) : base(notifications, _inMemoryBus)
        {
            _operatorRepository = operatorRepository;
            _encryptionService = encryptionService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
        {
            var existOperator = await _operatorRepository.GetByUserNameAsync(request.Email);
            if (existOperator != null)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var @operator = new Operator(displayName: request.DisplayName, email: request.Email, userName: request.Email,password: request.Password, encryptionService:_encryptionService);
            if (!IsValid(@operator))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _operatorRepository.CreateAsync(@operator);
          
            return new CommandResult(ApplicationMessages.Create_Success, @operator.Id.ToString());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateOperatorCommand request, CancellationToken cancellationToken)
        {
            var existOperator = await _operatorRepository.GetByUserNameAsync(request.Email);
            if (existOperator != null && existOperator.Id.ToString() != request.Id)
            {
                NotifyValidationError(request, ApplicationMessages.User_Email_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed);
            }

            var @operator = await _operatorRepository.GetByIdAsync(request.Id);
            if (@operator == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator);


            @operator.Update(request.DisplayName, request.Email, request.Email);
            if (!IsValid(@operator))
                return new CommandResult(ApplicationMessages.Update_Failed);

            await _operatorRepository.UpdateAsync(@operator);

            return new CommandResult(ApplicationMessages.Update_Success, @operator.Id.ToString());
        }


        #endregion

    }
}
