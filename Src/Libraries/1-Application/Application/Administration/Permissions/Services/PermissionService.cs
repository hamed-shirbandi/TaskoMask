using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Base.Services;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.Dtos.Administration.Permissions;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Application.Core.Dtos.Administration.Roles;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Administration.Permissions.Services
{
    public class PermissionService : BaseService<Permission>, IPermissionService
    {
        #region Fields

        private readonly IPermissionRepository _permissionRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IOperatorRepository _operatorRepository;

        #endregion

        #region Ctor

        public PermissionService(IPermissionRepository permissionRepository, IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, IRoleRepository roleRepository, IOperatorRepository operatorRepository)
            : base(inMemoryBus, mapper, notifications)
        {
            _permissionRepository = permissionRepository;
            _roleRepository = roleRepository;
            _operatorRepository = operatorRepository;
        }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(PermissionUpsertDto input)
        {
            if (await _permissionRepository.ExistBySystemNameAsync("", input.SystemName))
                return Result.Failure<CommandResult>(message: ApplicationMessages.Name_Already_Exist);

            var permission = new Permission
            {
                SystemName = input.SystemName,
                GroupName = input.GroupName,
                DisplayName = input.DisplayName
            };

            await _permissionRepository.CreateAsync(permission);

            return Result.Success(new CommandResult(id: permission.Id), ApplicationMessages.Create_Success);


        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(PermissionUpsertDto input)
        {
            if (await _permissionRepository.ExistBySystemNameAsync(input.Id, input.SystemName))
                return Result.Failure<CommandResult>(message: ApplicationMessages.Name_Already_Exist);

            var permission = await _permissionRepository.GetByIdAsync(input.Id);
            if (permission == null)
                return Result.Failure<CommandResult>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Permission));

            permission.SystemName = input.SystemName;
            permission.DisplayName = input.DisplayName;
            permission.GroupName = input.GroupName;

            await _permissionRepository.UpdateAsync(permission);

            return Result.Success(new CommandResult(id: permission.Id), ApplicationMessages.Update_Success);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PermissionBasicInfoDto>> GetByIdAsync(string id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null)
                return Result.Failure<PermissionBasicInfoDto>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Permission));

            return Result.Success(_mapper.Map<PermissionBasicInfoDto>(permission));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PermissionDetailViewModel>> GetDetailsAsync(string id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            if (permission == null)
                return Result.Failure<PermissionDetailViewModel>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Permission));


            var roles = await _roleRepository.GetListByPermissionIdAsync(id);


            var model = new PermissionDetailViewModel
            {
                Permission = _mapper.Map<PermissionUpsertDto>(permission),
                Roles = _mapper.Map<IEnumerable<RoleBasicInfoDto>>(roles)
            };
            return Result.Success(model);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<SelectListItem[]>> GetGroupedSelectListAsync()
        {
            var permissions = await _permissionRepository.GetListAsync();

            var model = permissions.GroupBy(p => p.GroupName).Select(p => new SelectListItem
            {
                Selected = false,
                Text = p.Key,
                Value = p.Key,

            }).ToArray();

            return Result.Success(model);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListAsync(string id)
        {
            var permissions = await _permissionRepository.GetListAsync();
            return Result.Success(_mapper.Map<IEnumerable<PermissionBasicInfoDto>>(permissions));

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListByIdsAsync(string[] ids)
        {
            var permissions = await _permissionRepository.GetListByIdsAsync(ids);
            return Result.Success(_mapper.Map<IEnumerable<PermissionBasicInfoDto>>(permissions));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<SelectListItem[]>> GetSelectListAsync(string[] selectedPermissionsId = null)
        {
            var permissions = await _permissionRepository.GetListByIdsAsync(selectedPermissionsId);
            var model = permissions.Select(p => new SelectListItem
            {
                Selected = selectedPermissionsId != null && selectedPermissionsId.Contains(p.Id),
                Text = p.DisplayName,
                Value = p.Id,

            }).ToArray();

            return Result.Success(model);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<PermissionBasicInfoDto>>> GetListByOperatorAsync(string userName)
        {
            var @operator = await _operatorRepository.GetByUserNameAsync(userName);
            if (@operator == null)
                return Result.Failure<IEnumerable<PermissionBasicInfoDto>>(message: string.Format(ApplicationMessages.Data_Not_exist, DomainMetadata.Operator));


            var roles = await _roleRepository.GetListByIdsAsync(@operator.RolesId);

            List<string> permissionsId = new();
            foreach (var item in roles)
                permissionsId.AddRange(item.PermissionsId);

            var permissions = await _permissionRepository.GetListByIdsAsync(permissionsId.ToArray());
            return Result.Success(_mapper.Map<IEnumerable<PermissionBasicInfoDto>>(permissions));

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string[]>> GetSystemNameListByOperatorAsync(string userName)
        {
            var operatorPermissionResult = await GetListByOperatorAsync(userName);
            if (!operatorPermissionResult.IsSuccess)
                return Result.Failure<string[]>(operatorPermissionResult.Errors);

            var permissions = operatorPermissionResult.Value.Select(p => p.SystemName).ToArray();
            return Result.Success(permissions);


        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PublicPaginatedListReturnType<PermissionOutputDto>>> SearchAsync(int page, int recordsPerPage, string term, string groupName)
        {
            var permissions = _permissionRepository.Search(page, recordsPerPage, term, groupName, out var pageNumber, out var totalCount);

            var permissionsDto = _mapper.Map<IEnumerable<PermissionOutputDto>>(permissions);

            foreach (var item in permissionsDto)
                item.RolesCount = await _roleRepository.CountByPermissionIdAsync(item.Id);

            var model = new PublicPaginatedListReturnType<PermissionOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = permissionsDto
            };

            return Result.Success(model);
        }



        #endregion
    }
}
