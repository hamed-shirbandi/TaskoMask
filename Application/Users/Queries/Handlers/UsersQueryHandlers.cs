using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Users.Queries.Handlers
{
    public class UsersQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetUserByIdQuery, UserBasicInfoDto>,
        IRequestHandler<GetUsersCountQuery, long>
    {
        #region Fields

        private readonly UserManager<User> _userManager;

        #endregion

        #region Ctors

        public UsersQueryHandlers(UserManager<User> userManager, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _userManager = userManager;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<UserBasicInfoDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            return _mapper.Map<UserBasicInfoDto>(user);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
        {
            return _userManager.Users.Count();
        }



        #endregion

    }
}
