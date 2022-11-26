using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Commands.Handlers
{
    public class TaskCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddTaskCommand, CommandResult>,
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

        public TaskCommandHandlers(ITaskAggregateRepository taskAggregateRepository, IMessageBus messageBus, ITaskValidatorService taskValidatorService, IBoardAggregateRepository boardAggregateRepository, IInMemoryBus inMemoryBus) : base(messageBus,inMemoryBus)
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
        public async Task<CommandResult> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByCardIdAsync(request.CardId);
            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            var task = Domain.DomainModel.Workspace.Tasks.Entities.Task.AddTask(request.Title, request.Description, request.CardId, board.Id, _taskValidatorService);

            await _taskAggregateRepository.AddAsync(task);
            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, task.Id);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.UpdateTask(request.Title, request.Description, _taskValidatorService);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);
            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, task.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            task.DeleteTask();

            await _taskAggregateRepository.DeleteAsync(task.Id);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(MoveTaskToAnotherCardCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.TaskId);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            if (task.CardId.Value==request.CardId)
                return new CommandResult(ContractsMessages.Update_Success, request.TaskId);


            var loadedVersion = task.Version;

            task.MoveTaskToAnotherCard(request.CardId);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.TaskId);

        }




        #endregion

    }
}
