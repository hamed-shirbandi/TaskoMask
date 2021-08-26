using AutoMapper;
using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Users.Services;
using TaskoMask.Application.Managers.Commands.Models;
using TaskoMask.Application.Managers.Queries.Models;
using TaskoMask.Application.Core.Dtos.Managers;

namespace TaskoMask.Application.Managers.Services
{
    public class ManagerService : UserService<Manager>, IManagerService
    {
        #region Fields

        #endregion

        #region Ctors

        public ManagerService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(UserInputDto input)
        {
            var cmd = new CreateManagerCommand(displayName: input.DisplayName, email: input.Email, password: input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UserInputDto input)
        {
            var cmd = new UpdateManagerCommand(id: input.Id, displayName: input.DisplayName, email: input.Email);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ManagerBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetManagerByIdQuery(id));
        }




        #endregion
    }
}
