using AutoMapper;
using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Services;


namespace TaskoMask.Application.Users.Services
{
    public class UserService<TEntity> : BaseApplicationService, IUserService where TEntity : User
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
        public async Task<Result<UserBasicInfoDto>> GetBaseUserByIdAsync(string id)
        {
            return await SendQueryAsync(new GetUserByIdQuery<TEntity>(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetBaseUserByUserNameAsync(string userName)
        {
            return await SendQueryAsync(new GetUserByUserNameQuery<TEntity>(userName));
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetBaseUserByPhoneNumberAsync(string phoneNumber)
        {
            return await SendQueryAsync(new GetUserByPhoneNumberQuery<TEntity>(phoneNumber));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<bool>> ValidateUserPasswordAsync(string userName, string password)
        {
            var query = new ValidateUserPasswordQuery<TEntity>(userName, password)
            {
                BypassCache = true
            };

            return await SendQueryAsync(query);
        }


        #endregion

    }
}
