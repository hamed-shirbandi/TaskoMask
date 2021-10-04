using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.TaskManagement.Tasks.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;


using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.TaskManagement.Data;
using TaskoMask.Domain.Team.Data;

namespace TaskoMask.Application.TaskManagement.Tasks.Commands.Handlers
{
    public class TaskCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateTaskCommand, CommandResult>,
         IRequestHandler<UpdateTaskCommand, CommandResult>
    {
        #region Fields

        private readonly ITaskRepository _taskRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public TaskCommandHandlers(ITaskRepository taskRepository, IDomainNotificationHandler notifications, IInMemoryBus _inMemoryBus) : base(notifications, _inMemoryBus)
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

            var card = await _cardRepository.GetByIdAsync(request.CardId);
            if (card == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Card);


            var board = await _boardRepository.GetByIdAsync(card.BoardId);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);


            var project = await _projectRepository.GetByIdAsync(board.ProjectId);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);


            var task = new Domain.TaskManagement.Entities.Task(title: request.Title, description: request.Description, cardId: request.CardId, boardId: card.BoardId, projectId: project.Id, organizationId: project.OrganizationId);
            if (!IsValid(task))
                return new CommandResult(ApplicationMessages.Create_Failed);

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

            task.Update(request.Title, request.Description);
            if (!IsValid(task))
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _taskRepository.UpdateAsync(task);
            return new CommandResult(ApplicationMessages.Update_Success, task.Id);

        }


        #endregion

    }
}
