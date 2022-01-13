using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Services;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Authorization.Entities;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Domain.Authorization.Data;

namespace TaskoMask.Application.Authorization.Users.Services
{
    public class UserService : BaseService<User>, IUserService
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
        public async Task<Result<CommandResult>> CreateAsync(UserUpsertDto input)
        {
            //move this validation to domain model
            var existOperator = await _operatorRepository.GetByUserNameAsync(input.UserName);
            if (existOperator != null)
                return Result.Failure<CommandResult>(message: ApplicationMessages.User_Email_Already_Exist);


            var userIdentity = UserIdentityBuilder.Init()
                .WithDisplayName(input.DisplayName)
                .WithEmail(input.Email)
                .WithPhoneNumber(input.PhoneNumber)
                .Build();

            var userAuthentication = UserAuthentication.Create(UserName.Create(input.UserName));

            var @operator = Operator.Create(userIdentity, userAuthentication);

            @operator.SetPassword(input.Password, _encryptionService);

            await _operatorRepository.CreateAsync(@operator);

            return Result.Success(new CommandResult(entityId: @operator.Id), ApplicationMessages.Create_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UserUpsertDto input)
        {
            //move this validation to domain model
            var existOperator = await _operatorRepository.GetByUserNameAsync(input.UserName);
            if (existOperator != null && existOperator.Id.ToString() != input.Id)
                return Result.Failure<CommandResult>(message: ApplicationMessages.User_Email_Already_Exist);


            var @operator = await _operatorRepository.GetByIdAsync(input.Id);
            if (@operator == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            @operator.Update(
                MemberDisplayName.Create(input.DisplayName),
                UserEmail.Create(input.Email),
                UserPhoneNumber.Create(input.PhoneNumber),
                UserName.Create(input.UserName));


            await _operatorRepository.UpdateAsync(@operator);

            return Result.Success(new CommandResult(entityId: @operator.Id), ApplicationMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<UserBasicInfoDto>> GetByUserNameAsync(string userName)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
                return Result.Failure<UserBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            return Result.Success(_mapper.Map<UserBasicInfoDto>(user));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<bool>> LoginAsync(string userName, string password)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user == null)
                return Result.Failure<bool>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.User));

            var isValid = user.IsValidPassword(password, _encryptionService);
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

            user.SetIsActive(isActive);

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

            user.ChangePassword(oldPassword, newPassword, _encryptionService);

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

            user.SetPassword(newPassword, _encryptionService);

            await _userRepository.UpdateAsync(user);

            return Result.Success(new CommandResult(entityId: user.Id), ApplicationMessages.Update_Success);
        }



        #endregion

    }
}
