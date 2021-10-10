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
        public async Task<Result<IEnumerable<RoleBasicInfoDto>>> GetListAsync()
        {
            return await SendQueryAsync(new GetRolesListQuery());
        }



        #endregion
    }
}
