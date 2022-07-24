using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Tasks.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Data;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Services;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Data;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Handlers
{
    public class TaskCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateTaskCommand, CommandResult>,
         IRequestHandler<UpdateTaskCommand, CommandResult>,
         IRequestHandler<MoveTaskToAnotherCardCommand, CommandResult>,
         IRequestHandler<DeleteTaskCommand, CommandResult>
    {
        #region Fields

        private readonly ITaskAggregateRepository _taskAggregateRepository;
        private readonly IBoardAggregateRepository _boardAggregateRepository;
        private readonly ITaskValidatorService _taskValidatorService;

        #endregion

        #region Ctors

        public TaskCommandHandlers(ITaskAggregateRepository taskAggregateRepository, IInMemoryBus inMemoryBus, ITaskValidatorService taskValidatorService, IBoardAggregateRepository boardAggregateRepository) : base(inMemoryBus)
        {
            _taskAggregateRepository = taskAggregateRepository;
            _taskValidatorService = taskValidatorService;
            _boardAggregateRepository = boardAggregateRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByCardIdAsync(request.CardId);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            var task = Domain.WriteModel.Workspace.Tasks.Entities.Task.CreateTask(request.Title, request.Description, request.CardId, board.Id, _taskValidatorService);

            await _taskAggregateRepository.CreateAsync(task);
            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Create_Success, task.Id);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.UpdateTask(request.Title, request.Description, _taskValidatorService);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);
            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, task.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.DeleteTask();

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, request.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(MoveTaskToAnotherCardCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.TaskId);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            if (task.CardId.Value==request.CardId)
                return new CommandResult(ApplicationMessages.Update_Success, request.TaskId);


            var loadedVersion = task.Version;

            task.MoveTaskToAnotherCard(request.CardId);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, request.TaskId);

        }




        #endregion

    }
}
