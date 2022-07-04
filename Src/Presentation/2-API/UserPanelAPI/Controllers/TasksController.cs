using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Tasks.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TasksController : BaseApiController, ITaskClientService
    {
        #region Fields

        private readonly ITaskService _taskService;

        #endregion

        #region Ctors

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// get task detail
        /// </summary>
        [HttpGet]
        [Route("tasks/{id}")]
        public async Task<Result<TaskBasicInfoDto>> Get(string id)
        {
            //TODO implement tasks get api
            return Result.Failure<TaskBasicInfoDto>(message: "not implemented yet");
        }





        /// <summary>
        /// Create new task
        /// </summary>
        [HttpPost]
        [Route("tasks")]
        public async Task<Result<CommandResult>> Create([FromBody] TaskUpsertDto input)
        {
            //TODO implement tasks create api
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }



        /// <summary>
        /// update task
        /// </summary>
        [HttpPut]
        [Route("tasks/{id}")]
        public async Task<Result<CommandResult>> Update(string id, [FromBody] TaskUpsertDto input)
        {
            input.Id = id;
            //TODO implement tasks Update api
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }



        /// <summary>
        /// change task's card
        /// </summary>
        [HttpPut]
        [Route("tasks/{taskId}/{cardId}")]
        public async Task<Result<CommandResult>> SetCardId(string taskId, string cardId)
        {
            //TODO implement tasks SetCardId
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }


        #endregion

    }
}
