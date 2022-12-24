using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Comments.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Monolith.Api.Controllers
{
    [Authorize("full-access")]
    public class CommentsApiController : BaseApiController
    {
        #region Fields

        private readonly ICommentService _commentService;
        private readonly IUserAccessManagementService _userAccessManagementService;

        #endregion

        #region Ctors

        public CommentsApiController(ICommentService commentService, IUserAccessManagementService userAccessManagementService)
        {
            _commentService = commentService;
            _userAccessManagementService = userAccessManagementService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get comment detail
        /// </summary>
        [HttpGet]
        [Route("comments/{id}")]
        public async Task<Result<GetCommentDto>> Get(string id)
        {
            return await _commentService.GetByIdAsync(id);
        }




        /// <summary>
        /// create new comment
        /// </summary>
        [HttpPost]
        [Route("comments")]
        public async Task<Result<CommandResult>> Add([FromBody] AddCommentDto input)
        {
            return await _commentService.AddAsync(input);
        }



        /// <summary>
        /// update existing comment
        /// </summary>
        [HttpPut]
        [Route("comments/{id}")]
        public async Task<Result<CommandResult>> Update(string id,[FromBody] UpdateCommentDto input)
        {
            input.Id = id;
            return await _commentService.UpdateAsync(input);
        }



        /// <summary>
        /// soft delete comment
        /// </summary>
        [HttpDelete]
        [Route("comments/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            return await _commentService.DeleteAsync(id);
        }




        #endregion

    }
}
