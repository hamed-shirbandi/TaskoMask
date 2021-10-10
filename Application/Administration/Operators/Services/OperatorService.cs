using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.BaseEntitiesUsers.Services;
using TaskoMask.Application.Administration.Operators.Commands.Models;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Administration.Operators.Queries.Models;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Administration.Operators.Services
{
    public class OperatorService : BaseUserService<Operator>, IOperatorService
    {
        #region Fields

        #endregion

        #region Ctors

        public OperatorService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(UserInputDto input)
        {
            var cmd = new CreateOperatorCommand(displayName: input.DisplayName, email: input.Email, password: input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UserInputDto input)
        {
            var cmd = new UpdateOperatorCommand(id: input.Id, displayName: input.DisplayName, email: input.Email);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId)
        {
            var cmd = new UpdateOperatorRolesCommand(id, rolesId);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetOperatorByIdQuery(id));
        }




        #endregion
    }
}
