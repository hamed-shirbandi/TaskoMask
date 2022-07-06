using MediatR;
using System.Threading;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks;

namespace TaskoMask.Application.Workspace.Tasks.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class TaskEventHandles : 
        INotificationHandler<TaskCreatedEvent>,
        INotificationHandler<TaskUpdatedEvent>,
        INotificationHandler<TaskDeletedEvent>,
        INotificationHandler<TaskMovedToAnotherCardEvent>,
        INotificationHandler<TaskRecycledEvent>
    {
        #region Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IBoardRepository _boardRepository;

        #endregion

        #region Ctors

        public TaskEventHandles(ITaskRepository taskRepository, IBoardRepository boardRepository)
        {
            _taskRepository = taskRepository;
            _boardRepository = boardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskCreatedEvent createdTask, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(createdTask.BoardId);

            var task = new Task(createdTask.Id)
            {
                Title= createdTask.Title,
                Description= createdTask.Description,
                CardId= createdTask.CardId,
                BoardId = createdTask.BoardId,
                OrganizationId= board.OrganizationId,
            };
           await _taskRepository.CreateAsync(task);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskUpdatedEvent updatedTask, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(updatedTask.Id);

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.CardId = updatedTask.CardId;

            task.SetAsUpdated();

            await _taskRepository.UpdateAsync(task);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskDeletedEvent deletedTask, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(deletedTask.Id);
            task.SetAsDeleted();
            await _taskRepository.UpdateAsync(task);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskMovedToAnotherCardEvent movedToAnotherCardEvent, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(movedToAnotherCardEvent.Id);
            task.CardId= movedToAnotherCardEvent.CardId;
            await _taskRepository.UpdateAsync(task);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskRecycledEvent recycledTask, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(recycledTask.Id);
            task.SetAsRecycled();
            await _taskRepository.UpdateAsync(task);
        }

        #endregion






    }
}
