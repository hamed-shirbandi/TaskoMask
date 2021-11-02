using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.BaseEntitiesUsers.Services;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Application.Core.ViewModels;
using System.Collections.Generic;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Dtos.Roles;
using System.Linq;

namespace TaskoMask.Application.Administration.Operators.Services
{
    public class OperatorService : BaseUserService<Operator>, IOperatorService
    {
        #region Fields

        private readonly IOperatorRepository _operatorRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IRoleRepository _roleRepository;


        #endregion

        #region Ctors

        public OperatorService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IOperatorRepository operatorRepository, IEncryptionService encryptionService, IRoleRepository roleRepository) : base(inMemoryBus, mapper, notifications,operatorRepository, encryptionService)
        {
            _operatorRepository = operatorRepository;
            _encryptionService = encryptionService;
            _roleRepository = roleRepository;
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(OperatorInputDto input)
        {
            var existOperator = await _operatorRepository.GetByUserNameAsync(input.Email);
            if (existOperator != null)
                return Result.Failure<CommandResult>(message: ApplicationMessages.User_Email_Already_Exist);


            var @operator = new Operator(displayName: input.DisplayName, phoneNumber: input.PhoneNumber, userName: input.UserName, email: input.Email, password: input.Password, encryptionService: _encryptionService);

            await _operatorRepository.CreateAsync(@operator);

            return Result.Success(new CommandResult(id: @operator.Id), ApplicationMessages.Create_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(OperatorInputDto input)
        {
            var existOperator = await _operatorRepository.GetByUserNameAsync(input.Email);
            if (existOperator != null && existOperator.Id.ToString() != input.Id)
                return Result.Failure<CommandResult>(message: ApplicationMessages.User_Email_Already_Exist);

            var @operator = await _operatorRepository.GetByIdAsync(input.Id);
            if (@operator == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            @operator.Update(input.DisplayName, input.Email, input.Email);

            await _operatorRepository.UpdateAsync(@operator);

            return Result.Success(new CommandResult(id: @operator.Id), ApplicationMessages.Update_Success);
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

            await _operatorRepository.UpdateAsync(@operator);

            return Result.Success(new CommandResult(id: @operator.Id), ApplicationMessages.Update_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OperatorBasicInfoDto>> GetByIdAsync(string id)
        {
            var @operator = await _operatorRepository.GetByIdAsync(id);
            if (@operator == null)
                return Result.Failure<OperatorBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            return Result.Success(_mapper.Map<OperatorBasicInfoDto>(@operator));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OperatorOutputDto>>> GetListAsync()
        {
            var operators = await _operatorRepository.GetListAsync();
            var operatorsDto = _mapper.Map<IEnumerable<OperatorOutputDto>>(operators);

            foreach (var item in operatorsDto)
                item.RolesCount = item.RolesId.Length;

            return Result.Success(operatorsDto);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OperatorDetailViewModel>> GetDetailsAsync(string id)
        {
            var @operator = await _operatorRepository.GetByIdAsync(id);
            if (@operator == null)
                return Result.Failure<OperatorDetailViewModel>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));

            var roles = await _roleRepository.GetListAsync();

            var model = new OperatorDetailViewModel
            {
                Operator = _mapper.Map<OperatorInputDto>(@operator),
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
