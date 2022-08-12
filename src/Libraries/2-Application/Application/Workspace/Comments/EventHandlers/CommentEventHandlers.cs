using MediatR;
using System.Threading;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Events.Comments;

namespace TaskoMask.Application.Workspace.Comments.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class CommentEventHandles :
        INotificationHandler<CommentAddedEvent>,
        INotificationHandler<CommentUpdatedEvent>,
        INotificationHandler<CommentDeletedEvent>
    {
        #region Fields

        private readonly ICommentRepository _commentRepository;
        private readonly ITaskRepository _taskRepository;

        #endregion

        #region Ctors

        public CommentEventHandles(ICommentRepository commentRepository, ITaskRepository taskRepository)
        {
            _commentRepository = commentRepository;
            _taskRepository = taskRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CommentAddedEvent createdComment, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(createdComment.TaskId);
            var comment = new Comment(createdComment.Id)
            {
                Content = createdComment.Content,
                TaskId = createdComment.TaskId,
            };
            await _commentRepository.CreateAsync(comment);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CommentUpdatedEvent updatedComment, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(updatedComment.Id);

            comment.Content = updatedComment.Content;

            comment.SetAsUpdated();

            await _commentRepository.UpdateAsync(comment);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CommentDeletedEvent deletedComment, CancellationToken cancellationToken)
        {
            await _commentRepository.DeleteAsync(deletedComment.Id);
        }




        #endregion






    }
}
