using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Domain.Core.Services;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Monolith.Application.Core.Services;
using TaskoMask.Services.Monolith.Domain.Core.Resources;

namespace TaskoMask.Services.Monolith.Application.Authorization.Users.Services
{
    public class UserService : ApplicationService, IUserService
    {
        #region Fields

        private readonly IUserRepository _userRepository;
        private readonly IEncryptionService _encryptionService;

        #endregion

        #region Ctors

        public UserService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IUserRepository userRepository, IEncryptionService encryptionService)
             : base(inMemoryBus, mapper, notifications)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<bool>> IsValidCredentialAsync(string userName, string password)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
                return Result.Failure<bool>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            if (user.IsActive == false)
                return Result.Failure<bool>(message: ApplicationMessages.User_Is_Not_Active_And_Can_Not_Login);


            var passwordHash = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);
            if (passwordHash != user.PasswordHash)
                return Result.Failure<bool>(message: ApplicationMessages.User_Login_failed);

            return Result.Success(true);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(string userName,string password,UserType type )
        {
            var existUser = await _userRepository.ExistByUserNameAsync(userName);
            if (existUser)
                return Result.Failure<CommandResult>(message: ApplicationMessages.User_Email_Already_Exist);


            if (!IsValidPassword(password))
                return Result.Failure<CommandResult>(message: string.Format(ContractsMetadata.Length_Error, nameof(password), DomainConstValues.User_Password_Min_Length, DomainConstValues.User_Password_Max_Length));


            var user = new User
            {
                UserName = userName,
                IsActive = true,
                Type= type
            };


            SetPassword(user, password);

            user.SetAsUpdated();

            await _userRepository.CreateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ContractsMessages.Create_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateUserNameAsync(string userId, string userName)
        {
            //move this validation to domain model
            var existUser = await _userRepository.GetByUserNameAsync(userName);
            if (existUser != null && existUser.Id.ToString() != userId)
                return Result.Failure<CommandResult>(message: ApplicationMessages.User_Already_Exist);


            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Operator));


            user.UserName = userName;

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ContractsMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> SetIsActiveAsync(string id, bool isActive)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            user.IsActive = isActive;

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ContractsMessages.Update_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> ChangePasswordAsync(string id, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            var validateOldPassword = await IsValidCredentialAsync(user.UserName, oldPassword);
            if (!validateOldPassword.IsSuccess)
                return Result.Failure<CommandResult>(message: DomainMessages.Incorrect_Old_Password);

            SetPassword(user, newPassword);

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ContractsMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> ResetPasswordAsync(string id, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            SetPassword(user, newPassword);

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ContractsMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            var count= await _userRepository.CountAsync();
            return Result.Success(count);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<CommandResult>(message: string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.User));

            user.SetAsDeleted();
            return Result.Success(new CommandResult(entityId: user.Id), ContractsMessages.Update_Success);
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < DomainConstValues.User_Password_Min_Length)
                return false;

            if (password.Length > DomainConstValues.User_Password_Max_Length)
                return false;

            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        private void SetPassword(User user, string password)
        {
            user.PasswordSalt = _encryptionService.CreateSaltKey(5);
            user.PasswordHash = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);
        }

        #endregion
    }
}
