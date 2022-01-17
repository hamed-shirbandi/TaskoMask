using AutoMapper;
using TaskoMask.Application.Share.Dtos.Ownership.Operators;
using TaskoMask.Application.Share.Dtos.Ownership.Permissions;
using TaskoMask.Application.Share.Dtos.Ownership.Roles;
using TaskoMask.Domain.Ownership.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class OwnershipMappingProfile : Profile
    {
        public OwnershipMappingProfile()
        {
            #region Role

            CreateMap<Role, RoleBasicInfoDto>();
            CreateMap<Role, RoleUpsertDto>();
            CreateMap<Role, RoleOutputDto>();
            CreateMap<RoleBasicInfoDto, RoleUpsertDto>();

            #endregion

            #region Permission

            CreateMap<Permission, PermissionBasicInfoDto>();
            CreateMap<Permission, PermissionUpsertDto>();
            CreateMap<Permission, PermissionOutputDto>();
            CreateMap<PermissionBasicInfoDto, PermissionUpsertDto>();

            #endregion

            #region Operator

            CreateMap<Operator, OperatorBasicInfoDto>();
            CreateMap<Operator, OperatorOutputDto>();

            #endregion

        }
    }
}
