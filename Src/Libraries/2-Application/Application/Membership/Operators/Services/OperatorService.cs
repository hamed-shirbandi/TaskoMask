using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Application.Share.ViewModels;
using System.Collections.Generic;
using TaskoMask.Domain.WriteModel.Membership.Data;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;
using System.Linq;
using TaskoMask.Application.Authorization.Users.Services;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Membership.Operators.Services
{
    public class OperatorService : ApplicationService, IOperatorService
    {
        #region Fields

        private readonly IOperatorRepository _operatorRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;

        #endregion

        #region Ctors

        public OperatorService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IOperatorRepository operatorRepository, IRoleRepository roleRepository, IUserService userService)
             : base(inMemoryBus, mapper, notifications)
        {
            _operatorRepository = operatorRepository;
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


            var @operator = new Operator(CreateUserCommandResult.Value.EntityId)
            {
                DisplayName = input.DisplayName,
                Email = input.Email,
            };


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
            @operator.SetAsUpdated();

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

            @operator.SetAsUpdated();

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
            model.UserInfo = userQueryResult.Value;

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
                    item.UserInfo = userQueryResult.Value;


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

            var operatorDto = _mapper.Map<OperatorBasicInfoDto>(@operator);

            var userQueryResult = await _userService.GetByIdAsync(id);
            if (!userQueryResult.IsSuccess)
                return Result.Failure<OperatorDetailsViewModel>(message: userQueryResult.Message);

            //add authentication info from user ti operator
            operatorDto.UserInfo = userQueryResult.Value;

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



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            var count = await _operatorRepository.CountAsync();
            return Result.Success(count);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var @operator = await _operatorRepository.GetByIdAsync(id);
            if (@operator == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            @operator.SetAsDeleteed();
            return Result.Success(new CommandResult(entityId: @operator.Id), ApplicationMessages.Update_Success);
        }


        #endregion
    }
}
