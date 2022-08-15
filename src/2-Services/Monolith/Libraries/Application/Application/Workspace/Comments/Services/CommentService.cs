using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Comments;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Bus;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Services
{
    public class CommentService : ApplicationService, ICommentService
    {
        #region Fields


        #endregion

        #region Ctors

        public CommentService(IInMemoryBus inMemoryBus, IMapper mapper, INotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        {
        }

        #endregion

        #region Public Methods




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
        public async Task<Result<IEnumerable<CommentBasicInfoDto>>> GetListByTaskIdAsync(string taskId)
        {
            return await SendQueryAsync(new GetCommentsByTaskIdQuery(taskId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddCommentDto input)
        {
            var cmd = new AddCommentCommand(taskId: input.TaskId, content: input.Content);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UpdateCommentDto input)
        {
            var cmd = new UpdateCommentCommand(id: input.Id, content: input.Content);
            return await SendCommandAsync(cmd);
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
