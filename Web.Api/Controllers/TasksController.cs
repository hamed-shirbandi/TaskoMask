using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.TaskManagement.Tasks.Services;
using TaskoMask.Application.Core.Dtos.Tasks;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TasksController : BaseApiController
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
        /// Create new task
        /// </summary>
        [HttpPost]
        [Route("tasks")]
        public async Task<Result<CommandResult>> Create(TaskInputDto input)
        {
            //TODO implement tasks create api
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }



        /// <summary>
        /// update task
        /// </summary>
        [HttpPut]
        [Route("tasks")]
        public async Task<Result<CommandResult>> Update(TaskInputDto input)
        {
            //TODO implement tasks Update api
            return Result.Failure<CommandResult>(message:"not implemented yet");
        }



        /// <summary>
        /// change task's card
        /// </summary>
        [HttpPut]
        [Route("tasks/{taskId}/{cardId}")]
        public async Task<Result<CommandResult>> SetCardId( string taskId,string cardId)
        {
            //TODO implement tasks SetCardId
            return Result.Failure<CommandResult>(message: "not implemented yet");
        }


        #endregion

    }
}
