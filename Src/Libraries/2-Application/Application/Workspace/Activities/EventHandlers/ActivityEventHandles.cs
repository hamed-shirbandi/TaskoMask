using MediatR;
using System.Threading;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Events.Tasks;

namespace TaskoMask.Application.Workspace.Activities.EventHandlers
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

        private readonly IActivityRepository _activityRepository;
        private readonly ICardRepository _cardRepository;

        #endregion

        #region Ctors

        public TaskEventHandles(IActivityRepository activityRepository, ICardRepository cardRepository)
        {
            _activityRepository = activityRepository;
            _cardRepository = cardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskCreatedEvent createdTask, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(createdTask.CardId);

            var activity = new Activity()
            {
                TaskId= createdTask.Id,
                Description= $"Added to {card.Name}",
            };
           await _activityRepository.CreateAsync(activity);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskUpdatedEvent updatedTask, CancellationToken cancellationToken)
        {
            var activity = new Activity()
            {
                TaskId = updatedTask.Id,
                Description = "Task Updated",
            };
            await _activityRepository.CreateAsync(activity);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskDeletedEvent deletedTask, CancellationToken cancellationToken)
        {
            var activity = new Activity()
            {
                TaskId = deletedTask.Id,
                Description = "Task Deleted",
            };
            await _activityRepository.CreateAsync(activity);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskMovedToAnotherCardEvent movedToAnotherCardEvent, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(movedToAnotherCardEvent.CardId);

            var activity = new Activity()
            {
                TaskId = movedToAnotherCardEvent.TaskId,
                Description = $"Moved to {card.Name}",
            };
            await _activityRepository.CreateAsync(activity);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskRecycledEvent recycledTask, CancellationToken cancellationToken)
        {
            var activity = new Activity()
            {
                TaskId = recycledTask.Id,
                Description = "Task Recycled",
            };
            await _activityRepository.CreateAsync(activity);
        }

        #endregion

    }
}
