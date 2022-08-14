using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using MediatR;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Handlers
{
    public class CommentCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddCommentCommand, CommandResult>,
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
        public async Task<CommandResult> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByIdAsync(request.TaskId);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            var comment = Comment.Create(content: request.Content);
            task.AddComment(comment);

            await _taskAggregateRepository.UpdateAsync(task);
            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, comment.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByCommentIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.UpdateComment(request.Id, request.Content);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, request.Id);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskAggregateRepository.GetByCommentIdAsync(request.Id);
            if (task == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

            var loadedVersion = task.Version;

            task.DeleteComment(request.Id);

            await _taskAggregateRepository.ConcurrencySafeUpdate(task, loadedVersion);

            await PublishDomainEventsAsync(task.DomainEvents);

            return new CommandResult(ContractsMessages.Update_Success, task.Id);

        }

        #endregion

    }
}
