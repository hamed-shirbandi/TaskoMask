﻿using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Comments.Commands.Models;
using TaskoMask.Application.Workspace.Comments.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Comments;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Services.Application;
using TaskoMask.Application.Workspace.Tasks.Services;

namespace TaskoMask.Application.Workspace.Comments.Services
{
    public class CommentService : ApplicationService, ICommentService
    {
        #region Fields

        private readonly ITaskService _taskService;

        #endregion

        #region Ctors

        public CommentService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, ITaskService taskService) : base(inMemoryBus, mapper, notifications)
        {
            _taskService = taskService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(CommentUpsertDto input)
        {
            var cmd = new CreateCommentCommand(taskId: input.TaskId, content: input.Content);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(CommentUpsertDto input)
        {
            var cmd = new UpdateCommentCommand(id: input.Id, content: input.Content);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommentBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetCommentByIdQuery(id));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteCommentCommand(id);
            return await SendCommandAsync(cmd);
        }


        #endregion


        #region Private Methods



        #endregion
    }
}