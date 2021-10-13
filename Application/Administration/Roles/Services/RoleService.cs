using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Administration.Roles.Commands.Models;
using TaskoMask.Application.Administration.Roles.Queries.Models;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Application.Common.BaseEntities.Services;
using TaskoMask.Application.Core.Dtos.Roles;
using System.Collections.Generic;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Administration.Operators.Queries.Models;

namespace TaskoMask.Application.Administration.Roles.Services
{
    public class RoleService : BaseEntityService<Operator>, IRoleService
    {
        #region Fields

        #endregion

        #region Ctors

        public RoleService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(RoleInputDto input)
        {
            var cmd = new CreateRoleCommand(name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(RoleInputDto input)
        {
            var cmd = new UpdateRoleCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetRoleByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<RoleOutputDto>>> GetListAsync()
        {
            return await SendQueryAsync(new GetRolesListQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<RoleDetailViewModel>> GetDetailsAsync(string id)
        {
            var operatorsQueryResult = await SendQueryAsync(new GetOperatorsByRoleIdQuery(roleId: id));
            if (!operatorsQueryResult.IsSuccess)
                return Result.Failure<RoleDetailViewModel>(operatorsQueryResult.Errors);

            var roleQueryResult = await SendQueryAsync(new GetRoleByIdQuery(id));
            if (!roleQueryResult.IsSuccess)
                return Result.Failure<RoleDetailViewModel>(roleQueryResult.Errors);

            var model = new RoleDetailViewModel
            {
                Role = roleQueryResult.Value,
                Operators = operatorsQueryResult.Value,
            };

            return Result.Success(model);

        }



        #endregion
    }
}
