using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.BaseEntities.Services;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Application.Common.BaseEntitiesUsers.Services
{
    public class BaseUserService<TEntity> : BaseEntityService<TEntity>, IBaseUserService where TEntity : BaseUser
    {
        #region Fields

        private readonly IUserBaseRepository<TEntity> _userRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors

        public BaseUserService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IUserBaseRepository<TEntity> userRepository, IEncryptionService encryptionService) : base(inMemoryBus, mapper, notifications)
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

            return Result.Success(new CommandResult(id: user.Id), ApplicationMessages.Update_Success);

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

            return Result.Success(new CommandResult(id: user.Id), ApplicationMessages.Update_Success);
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

            return Result.Success(new CommandResult(id: user.Id), ApplicationMessages.Update_Success);
        }



        #endregion

    }
}
