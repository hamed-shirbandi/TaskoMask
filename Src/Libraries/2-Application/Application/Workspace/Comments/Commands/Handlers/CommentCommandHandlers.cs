using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Comments.Commands.Models;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using MediatR;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;

namespace TaskoMask.Application.Workspace.Comments.Commands.Handlers
{
    public class CommentCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateCommentCommand, CommandResult>,
         IRequestHandler<UpdateCommentCommand, CommandResult>,
         IRequestHandler<DeleteCommentCommand, CommandResult>
    {
        #region Fields

        private readonly ITaskAggregateRepository _taskAggregateRepository;


        #endregion

        #region Ctors

        public CommentCommandHandlers(ITaskAggregateRepository taskAggregateRepository, IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
            _taskAggregateRepository = taskAggregateRepository;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.TaskId);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            var comment = Comment.Create(content: request.Content);
            task.CreateComment(comment);

            await _taskAggregateRepository.UpdateAsync(task);
            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Create_Success, comment.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByCommentIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.UpdateComment(request.Id, request.Content);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, request.Id);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByCommentIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.DeleteComment(request.Id);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, task.Id);

        }

        #endregion

    }
}
