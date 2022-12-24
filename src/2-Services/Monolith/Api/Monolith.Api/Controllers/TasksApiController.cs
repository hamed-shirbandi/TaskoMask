using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Workspace.Tasks.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using Microsoft.AspNetCore.Authorization;

namespace TaskoMask.Services.Monolith.Api.Controllers
{
    [Authorize("full-access")]
    public class TasksApiController : BaseApiController
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
        public async Task<Result<GetTaskDto>> Get(string id)
        {
            if (!await _userAccessManagementService.CanAccessToTaskAsync(id))
                return Result.Failure<GetTaskDto>(message: ContractsMessages.Access_Denied);

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
                return Result.Failure<TaskDetailsViewModel>(message: ContractsMessages.Access_Denied);

            return await _taskService.GetDetailsAsync(id);
        }





        /// <summary>
        /// create new task
        /// </summary>
        [HttpPost]
        [Route("tasks")]
        public async Task<Result<CommandResult>> Add([FromBody] AddTaskDto input)
        {
            return await _taskService.AddAsync(input);
        }



        /// <summary>
        /// update task
        /// </summary>
        [HttpPut]
        [Route("tasks/{id}")]
        public async Task<Result<CommandResult>> Update(string id, [FromBody] UpdateTaskDto input)
        {
            if (!await _userAccessManagementService.CanAccessToTaskAsync(id))
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

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
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

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
                return Result.Failure<CommandResult>(message: ContractsMessages.Access_Denied);

            return await _taskService.DeleteAsync(id);
        }


        #endregion

    }
}
