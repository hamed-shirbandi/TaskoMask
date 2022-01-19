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
using TaskoMask.Domain.Workspace.Tasks.Data;
using TaskoMask.Domain.Workspace.Boards.Data;
using TaskoMask.Domain.Workspace.Organizations.Data;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Handlers
{
    public class TaskCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateTaskCommand, CommandResult>,
         IRequestHandler<UpdateTaskCommand, CommandResult>
    {
        #region Fields

        private readonly ITaskAggregateRepository _taskRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IBoardAggregateRepository _boardRepository;
        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public TaskCommandHandlers(ITaskAggregateRepository taskRepository, IDomainNotificationHandler notifications, IInMemoryBus inMemoryBus) : base(notifications, inMemoryBus)
        {
            _taskRepository = taskRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var exist = await _taskRepository.ExistByTitleAsync("", request.Title);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            //var card = await _cardRepository.GetByIdAsync(request.CardId);
            //if (card == null)
            //    throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Card);


            //var board = await _boardRepository.GetByIdAsync(card.BoardId);
            //if (board == null)
            //    throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);


            //var project = await _projectRepository.GetByIdAsync(board.ProjectId);
            //if (project == null)
            //    throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);

            var task = Domain.Workspace.Tasks.Entities.Task.CreateTask(title: request.Title, description: request.Description, cardId: request.CardId);

            await _taskRepository.CreateAsync(task);
            return new CommandResult(ApplicationMessages.Create_Success, task.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            var exist = await _taskRepository.ExistByTitleAsync(task.Id, request.Title);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            task.UpdateTask(request.Title, request.Description);

            await _taskRepository.UpdateAsync(task);
            return new CommandResult(ApplicationMessages.Update_Success, task.Id);

        }


        #endregion

    }
}
