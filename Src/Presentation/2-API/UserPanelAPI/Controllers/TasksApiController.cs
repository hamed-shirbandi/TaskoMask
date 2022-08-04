using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Workspace.Tasks.Services;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Presentation.Framework.Web.Controllers;
using TaskoMask.Application.Share.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Core.Services;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Presentation.API.UserPanelAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TasksApiController : BaseApiController, ITaskApiService
    {
        #region Fields

        private readonly ITaskService _taskService;
        private readonly IUserAccessManagementService _userAccessManagementService;

        #endregion

        #region Ctors

        public TasksApiController(ITaskService taskService, IUserAccessManagementService userAccessManagementService)
        {
            _taskService = taskService;
            _userAccessManagementService = userAccessManagementService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// get task
        /// </summary>
        [HttpGet]
        [Route("tasks/{id}")]
        public async Task<Result<TaskBasicInfoDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToTaskAsync(id))
                return Result.Failure<TaskBasicInfoDto>(message: DomainMessages.Access_Denied);

            return await _taskService.GetByIdAsync(id);
        }



        /// <summary>
        /// get task details
        /// </summary>
        [HttpGet]
        [Route("tasks/{id}/details")]
        public async Task<Result<TaskDetailsViewModel>> GetDetails(string id)
        {
            if (!await _userAccessManagementService.CanAccessToTaskAsync(id))
                return Result.Failure<TaskDetailsViewModel>(message: DomainMessages.Access_Denied);

            return await _taskService.GetDetailsAsync(id);
        }





        /// <summary>
        /// create new task
        /// </summary>
        [HttpPost]
        [Route("tasks")]
        public async Task<Result<CommandResult>> Add([FromBody] TaskUpsertDto input)
        {
            return await _taskService.AddAsync(input);
        }



        /// <summary>
        /// update task
        /// </summary>
        [HttpPut]
        [Route("tasks/{id}")]
        public async Task<Result<CommandResult>> Update(string id, [FromBody] TaskUpsertDto input)
        {
            if (!await _userAccessManagementService.CanAccessToTaskAsync(id))
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            input.Id = id;
            return await _taskService.UpdateAsync(input);
        }



        /// <summary>
        /// moce a task to another card
        /// </summary>
        [HttpPut]
        [Route("tasks/{taskId}/moveto/{cardId}")]
        public async Task<Result<CommandResult>> MoveTaskToAnotherCard(string taskId, string cardId)
        {

            if (!await _userAccessManagementService.CanAccessToTaskAsync(taskId))
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            return await _taskService.MoveTaskToAnotherCardAsync(taskId, cardId);

        }


        /// <summary>
        /// soft delete a task
        /// </summary>
        [HttpDelete]
        [Route("tasks/{id}")]
        public async Task<Result<CommandResult>> Delete(string id)
        {
            if (!await _userAccessManagementService.CanAccessToTaskAsync(id))
                return Result.Failure<CommandResult>(message: DomainMessages.Access_Denied);

            return await _taskService.DeleteAsync(id);
        }


        #endregion

    }
}
