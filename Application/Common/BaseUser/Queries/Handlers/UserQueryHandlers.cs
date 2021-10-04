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
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Users.Queries.Handlers
{
    public class UserQueryHandlers<TEnitity> : BaseQueryHandler,
        IRequestHandler<GetUserByIdQuery<TEnitity>, UserBasicInfoDto>,
        IRequestHandler<GetUserByPhoneNumberQuery<TEnitity>, UserBasicInfoDto>,
        IRequestHandler<ValidateUserPasswordQuery<TEnitity>, bool>,
        IRequestHandler<GetUserByUserNameQuery<TEnitity>, UserBasicInfoDto> where TEnitity :BaseUser
    {
        #region Fields

        private readonly IUserBaseRepository<TEnitity> _userRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors

        public UserQueryHandlers(IUserBaseRepository<TEnitity> userRepository, IDomainNotificationHandler notifications, IMapper mapper, IEncryptionService encryptionService) : base(mapper, notifications)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<UserBasicInfoDto> Handle(GetUserByIdQuery<TEnitity> request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            return _mapper.Map<UserBasicInfoDto>(user);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<UserBasicInfoDto> Handle(GetUserByUserNameQuery<TEnitity> request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            return _mapper.Map<UserBasicInfoDto>(user);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<UserBasicInfoDto> Handle(GetUserByPhoneNumberQuery<TEnitity> request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(request.PhoneNumber);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            return _mapper.Map<UserBasicInfoDto>(user);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> Handle(ValidateUserPasswordQuery<TEnitity> request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            var isValid = user.ValidatePassword(request.Password, _encryptionService);
            if (!isValid)
                NotifyValidationError(request, ApplicationMessages.User_Login_failed);

            return isValid;
        }


        #endregion


        #region Private Methods




        #endregion
    }
}
