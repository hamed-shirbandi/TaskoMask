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
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Application.Users.Queries.Handlers
{
    public class UsersQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetUserByIdQuery, UserBasicInfoDto>,
        IRequestHandler<ValidateUserPasswordQuery, bool>,
        IRequestHandler<GetUserByUserNameQuery, UserBasicInfoDto>
    {
        #region Fields

        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors

        public UsersQueryHandlers(IUserRepository userRepository, IDomainNotificationHandler notifications, IMapper mapper, IEncryptionService encryptionService) : base(mapper, notifications)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
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




        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> Handle(ValidateUserPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);


            return user.ValidatePassword(request.Password,_encryptionService);
        }


        #endregion


        #region Private Methods

   


        #endregion
    }
}
