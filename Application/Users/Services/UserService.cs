using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Users.Services
{
    public class UserService : BaseApplicationService, IUserService
    {
        #region Fields

        #endregion

        #region Ctor

        public UserService(IMediator mediator, IMapper mapper, INotificationHandler<DomainNotification> notifications) : base(mediator, mapper, notifications)
        { }


        #endregion

        #region Command Services

        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(RegisterViewModel input)
        {
            var createCommand = _mapper.Map<CreateUserCommand>(input);
            return await SendCommandAsync(createCommand);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UserInput input)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(input);
            return await SendCommandAsync(updateCommand);
        }


        #endregion

        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<UserOutput> GetByIdAsync(string id)
        {
            var query = new GetUserByIdQuery(id);
            return await SendQueryAsync<GetUserByIdQuery, UserOutput>(query);
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<UserInput> GetByIdToUpdateAsync(string id)
        {
            var user = await GetByIdAsync(id);
            return _mapper.Map<UserInput>(user);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountAsync()
        {
            var query = new GetUsersCountQuery();
            return await SendQueryAsync<GetUsersCountQuery, long>(query);
        }


        #endregion

    }

}
