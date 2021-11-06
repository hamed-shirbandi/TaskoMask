using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.TaskManagement.Tasks.Commands.Models;
using TaskoMask.Application.TaskManagement.Tasks.Queries.Models;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;
using TaskoMask.Application.Core.Commands;
using System.Collections.Generic;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Base.Services;

namespace TaskoMask.Application.TaskManagement.Tasks.Services
{
    public class TaskService : BaseService<Domain.TaskManagement.Entities.Task>, ITaskService
    {
        #region Fields


        #endregion

        #region Ctors

        public TaskService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(TaskUpsertDto input)
        {
            var cmd = new CreateTaskCommand(cardId: input.CardId, title: input.Title, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(TaskUpsertDto input)
        {
            var cmd = new UpdateTaskCommand(id: input.Id, name: input.Title, description: input.Description);
            return await SendCommandAsync(cmd);
        }



 


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<TaskBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetTaskByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<TaskBasicInfoDto>>> GetListByCardIdAsync(string cardId)
        {
            return await SendQueryAsync(new GetTasksByCardIdQuery(cardId));
        }



      


        #endregion
    }
}
