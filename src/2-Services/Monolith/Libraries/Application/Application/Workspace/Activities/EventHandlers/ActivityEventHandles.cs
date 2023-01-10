using MediatR;
using System.Threading;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Events.Tasks;

namespace TaskoMask.Services.Monolith.Application.Workspace.Activities.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class TaskEventHandles : 
        INotificationHandler<TaskAddedEvent>,
        INotificationHandler<TaskUpdatedEvent>,
        INotificationHandler<TaskDeletedEvent>,
        INotificationHandler<TaskMovedToAnotherCardEvent>
    {
        #region Fields

        private readonly IActivityRepository _activityRepository;

        #endregion

        #region Ctors

        public TaskEventHandles(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskAddedEvent createdTask, CancellationToken cancellationToken)
        {

            var activity = new Activity()
            {
                TaskId= createdTask.Id,
                Description= "Added to {card.Name}",
            };
           await _activityRepository.AddAsync(activity);
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
            await _activityRepository.AddAsync(activity);

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
            await _activityRepository.AddAsync(activity);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskMovedToAnotherCardEvent movedToAnotherCardEvent, CancellationToken cancellationToken)
        {

            var activity = new Activity()
            {
                TaskId = movedToAnotherCardEvent.TaskId,
                Description = "Moved to {card.Name}",
            };
            await _activityRepository.AddAsync(activity);

        }

        #endregion

    }
}
