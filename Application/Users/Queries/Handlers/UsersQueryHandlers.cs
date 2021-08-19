using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Users.Queries.Handlers
{
    public class UsersQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetUserByIdQuery, UserBasicInfoDto>,
        IRequestHandler<GetUserByUserNameQuery, UserBasicInfoDto>
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctors

        public UsersQueryHandlers(IUserRepository userRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<UserBasicInfoDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            return _mapper.Map<UserBasicInfoDto>(user);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<UserBasicInfoDto> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            return _mapper.Map<UserBasicInfoDto>(user);
        }


        #endregion

    }
}
