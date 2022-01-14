using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Domain.Membership.Entities;
using TaskoMask.Application.Share.ViewModels;
using System.Collections.Generic;
using TaskoMask.Domain.Membership.Data;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Share.Resources;
using System.Linq;
using TaskoMask.Application.Common.Services;
using TaskoMask.Application.Authorization.Users.Services;

namespace TaskoMask.Application.Membership.Operators.Services
{
    public class OperatorService : BaseService<Operator>, IOperatorService
    {
        #region Fields

        private readonly IOperatorRepository _operatorRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;

        #endregion

        #region Ctors

        public OperatorService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IOperatorRepository operatorRepository, IEncryptionService encryptionService, IRoleRepository roleRepository, IUserService userService)
             : base(inMemoryBus, mapper, notifications)
        {
            _operatorRepository = operatorRepository;
            _encryptionService = encryptionService;
            _roleRepository = roleRepository;
            _userService = userService;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(OperatorUpsertDto input)
        {
            //create authentication user info
            var CreateUserCommandResult = await _userService.CreateAsync(input.UserName, input.Password);
            if (!CreateUserCommandResult.IsSuccess)
                return CreateUserCommandResult;


            var @operator = new Operator
            {
                DisplayName = input.DisplayName,
                Email = input.Email,
            };

            //Share key between User and Operator
            @operator.SetId(CreateUserCommandResult.Value.EntityId);

            await _operatorRepository.CreateAsync(@operator);

            return Result.Success(new CommandResult(entityId: @operator.Id), ApplicationMessages.Create_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(OperatorUpsertDto input)
        {

            var @operator = await _operatorRepository.GetByIdAsync(input.Id);
            if (@operator == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));


            //create authentication user info
            var CreateUserCommandResult = await _userService.UpdateUserNameAsync(input.Id, input.UserName);
            if (!CreateUserCommandResult.IsSuccess)
                return CreateUserCommandResult;

            @operator.DisplayName = input.DisplayName;
            @operator.Email = input.Email;
            @operator.UpdateModifiedDateTime();

            await _operatorRepository.UpdateAsync(@operator);

            return Result.Success(new CommandResult(entityId: @operator.Id), ApplicationMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateRolesAsync(string id, string[] rolesId)
        {
            var @operator = await _operatorRepository.GetByIdAsync(id);
            if (@operator == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            @operator.RolesId = rolesId;

            @operator.UpdateModifiedDateTime();

            await _operatorRepository.UpdateAsync(@operator);

            return Result.Success(new CommandResult(entityId: @operator.Id), ApplicationMessages.Update_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id)
        {
            var @operator = await _operatorRepository.GetByIdAsync(id);
            if (@operator == null)
                return Result.Failure<OperatorBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            var userQueryResult = await _userService.GetByIdAsync(id);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<OperatorBasicInfoDto>(message: userQueryResult.Message);

            var model = _mapper.Map<OperatorBasicInfoDto>(@operator);

            //add authentication info from user ti operator
            model.IsActive = userQueryResult.Value.IsActive;
            model.UserName = userQueryResult.Value.UserName;

            return Result.Success(model);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OperatorOutputDto>>> GetListAsync()
        {
            var operators = await _operatorRepository.GetListAsync();
            var operatorsDto = _mapper.Map<IEnumerable<OperatorOutputDto>>(operators);

            foreach (var item in operatorsDto)
            {
                //add authentication info from user to operator
                var userQueryResult = await _userService.GetByIdAsync(item.Id);
                if (!userQueryResult.IsSuccess)
                {
                    item.IsActive = userQueryResult.Value.IsActive;
                    item.UserName = userQueryResult.Value.UserName;
                }

                item.RolesCount = item.RolesId.Length;

            }

            return Result.Success(operatorsDto);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OperatorDetailsViewModel>> GetDetailsAsync(string id)
        {
            var @operator = await _operatorRepository.GetByIdAsync(id);
            if (@operator == null)
                return Result.Failure<OperatorDetailsViewModel>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            //add authentication info from user ti operator
            var userQueryResult = await _userService.GetByIdAsync(id);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<OperatorDetailsViewModel>(message: userQueryResult.Message);

            var operatorDto = _mapper.Map<OperatorBasicInfoDto>(@operator);
            operatorDto.IsActive = userQueryResult.Value.IsActive;
            operatorDto.UserName = userQueryResult.Value.UserName;


            var roles = await _roleRepository.GetListAsync();

            var model = new OperatorDetailsViewModel
            {
                Operator = operatorDto,
                Roles = roles.Select(role => new SelectListItem
                {
                    Selected = @operator.RolesId != null && @operator.RolesId.Contains(role.Id),
                    Text = role.Name,
                    Value = role.Id,
                }).AsEnumerable(),
            };

            return Result.Success(model);
        }


        #endregion
    }
}
