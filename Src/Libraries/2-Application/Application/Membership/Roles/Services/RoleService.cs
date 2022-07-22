using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Application.Share.Dtos.Membership.Roles;
using System.Collections.Generic;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Domain.WriteModel.Membership.Data;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using System.Linq;
using TaskoMask.Application.Core.Services.Application;

namespace TaskoMask.Application.Membership.Roles.Services
{
    public class RoleService : ApplicationService, IRoleService
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly IOperatorRepository _operatorRepository;
        private readonly IPermissionRepository _permissionRepository;


        #endregion

        #region Ctors

        public RoleService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IRoleRepository roleRepository, IOperatorRepository operatorRepository, IPermissionRepository permissionRepository) : base(inMemoryBus, mapper, notifications)
        {
            _roleRepository = roleRepository;
            _operatorRepository = operatorRepository;
            _permissionRepository = permissionRepository;
        }


        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(RoleUpsertDto input)
        {
            if (await _roleRepository.ExistByNameAsync("", input.Name))
                return Result.Failure<CommandResult>(message: ApplicationMessages.Name_Already_Exist);

            var role = new Role
            {
                Name = input.Name,
                Description = input.Description,
            };

            await _roleRepository.CreateAsync(role);

            return Result.Success(new CommandResult(entityId: role.Id), ApplicationMessages.Create_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(RoleUpsertDto input)
        {
            if (await _roleRepository.ExistByNameAsync(input.Id, input.Name))
                return Result.Failure<CommandResult>(message: ApplicationMessages.Name_Already_Exist);

            var role = await _roleRepository.GetByIdAsync(input.Id);
            if (role == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Role));

            role.Name = input.Name;
            role.Description = input.Description;

            await _roleRepository.UpdateAsync(role);

            return Result.Success(new CommandResult(entityId: role.Id), ApplicationMessages.Update_Success);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdatePermissionsAsync(string id, string[] permissionsId)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Role));

            role.PermissionsId = permissionsId;

            await _roleRepository.UpdateAsync(role);

            return Result.Success(new CommandResult(entityId: role.Id), ApplicationMessages.Update_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<RoleBasicInfoDto>> GetByIdAsync(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return Result.Failure<RoleBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Role));

            return Result.Success(_mapper.Map<RoleBasicInfoDto>(role));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<RoleOutputDto>>> GetListAsync()
        {
            var roles = await _roleRepository.GetListAsync();
            var rolesDto = _mapper.Map<IEnumerable<RoleOutputDto>>(roles);

            foreach (var item in rolesDto)
            {
                item.OperatorsCount = await _operatorRepository.CountByRoleIdAsync(item.Id);
                item.PermissionsCount = item.PermissionsId.Length;
            }

            return Result.Success(rolesDto);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<RoleDetailsViewModel>> GetDetailsAsync(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return Result.Failure<RoleDetailsViewModel>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Role));


            var operators = await _operatorRepository.GetListByRoleIdAsync(id);
            var permissions = await _permissionRepository.GetListAsync();


            var model = new RoleDetailsViewModel
            {
                Role = _mapper.Map<RoleUpsertDto>(role),
                Operators = _mapper.Map<IEnumerable<OperatorBasicInfoDto>>(operators),
                Permissions = permissions.GroupBy(p => p.GroupName)
                    .ToDictionary(p => p.Key, p => p.ToList().Select(d => new SelectListItem
                    {
                        Selected = role.PermissionsId != null && role.PermissionsId.Contains(d.Id),
                        Text = d.DisplayName,
                        Value = d.Id,
                    }).AsEnumerable()),
            };

            return Result.Success(model);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            var count = await _roleRepository.CountAsync();
            return Result.Success(count);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Role));

            role.SetAsDeleted();
            return Result.Success(new CommandResult(entityId: role.Id), ApplicationMessages.Update_Success);
        }




        #endregion
    }
}
