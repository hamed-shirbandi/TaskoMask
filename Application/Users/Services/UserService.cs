using AutoMapper;
using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Users.Services
{
    public class UserService : BaseEntityService<User>, IUserService
    {
        #region Fields

        #endregion

        #region Ctors

        public UserService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(UserInputDto input)
        {
            var cmd = new CreateUserCommand(displayName: input.DisplayName, email: input.Email,password:input.Password);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UserInputDto input)
        {
            var cmd = new UpdateUserCommand(id: input.Id, displayName: input.DisplayName, email: input.Email);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetAsync(string id)
        {
            return await SendQueryAsync(new GetUserByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetByUserNameAsync(string userName)
        {
            return await SendQueryAsync(new GetUserByUserNameQuery(userName));
        }



        #endregion

    }

}
