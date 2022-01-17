using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Common.Commands.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Common.Commands.Handlers
{
    public class BaseCommandHandlers<TEntity> : BaseCommandHandler,
        IRequestHandler<RecycleCommand<TEntity>, CommandResult>,
        IRequestHandler<DeleteCommand<TEntity>, CommandResult> where TEntity : BaseEntity

    {
        #region Fields


        private readonly IBaseAggregateRepository<TEntity> _baseRepository;


        #endregion


        #region Ctor


        public BaseCommandHandlers(IBaseAggregateRepository<TEntity> baseRepository, IDomainNotificationHandler notifications , IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _baseRepository = baseRepository;
        }


        #endregion


        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await _baseRepository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Entity);

            entity.Delete();
            entity.UpdateModifiedDateTime();

            await _baseRepository.UpdateAsync(entity);
            return new CommandResult(ApplicationMessages.Delete_Success, entity.Id);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(RecycleCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await _baseRepository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Entity);

            entity.Recycle();

            await _baseRepository.UpdateAsync(entity);
            return new CommandResult(ApplicationMessages.Update_Success, entity.Id);
        }


        #endregion


    }
}
