using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Base.Services;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Common.Users.Services
{
    public class UserService<TEntity> : BaseService<TEntity>, IUserService where TEntity : UserAuthentication
    {
        #region Fields

        private readonly IUserRepository<TEntity> _userRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors

        public UserService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IUserRepository<TEntity> userRepository, IEncryptionService encryptionService) : base(inMemoryBus, mapper, notifications)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetBaseUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetBaseUserByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetBaseUserByPhoneNumberAsync(string phoneNumber)
        {
            var user = await _userRepository.GetByPhoneNumberAsync(phoneNumber);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<bool>> ValidateUserPasswordAsync(string userName, string password)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
                return Result.Failure<bool>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            var isValid = user.ValidatePassword(password, _encryptionService);
            if (!isValid)
                return Result.Failure<bool>(message: ApplicationMessages.User_Login_failed);

            return Result.Success(isValid);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> SetIsActiveAsync(string id, bool isActive)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            user.SetActive(isActive);

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ApplicationMessages.Update_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> ChangePasswordAsync(string id, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            var validOldPass = await ValidateUserPasswordAsync(user.UserName, oldPassword);
            if (validOldPass.IsSuccess == false || validOldPass.Value == false)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.User_Login_failed, DomainMetadata.User));

            user.ResetPassword(newPassword, _encryptionService);

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ApplicationMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> ResetPasswordAsync(string id, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            user.ResetPassword(newPassword, _encryptionService);

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ApplicationMessages.Update_Success);
        }



        #endregion

    }
}
