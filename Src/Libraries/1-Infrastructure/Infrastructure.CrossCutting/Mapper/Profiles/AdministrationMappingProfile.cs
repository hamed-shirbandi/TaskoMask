using AutoMapper;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Application.Share.Dtos.Membership.Permissions;
using TaskoMask.Application.Share.Dtos.Membership.Roles;
using TaskoMask.Domain.Membership.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class MembershipMappingProfile : Profile
    {
        public MembershipMappingProfile()
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
