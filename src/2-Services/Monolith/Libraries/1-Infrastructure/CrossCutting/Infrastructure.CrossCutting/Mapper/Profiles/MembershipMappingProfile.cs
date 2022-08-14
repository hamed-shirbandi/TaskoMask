using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Permissions;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Roles;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;

namespace TaskoMask.Services.Monolith.Application.Mapper.Profiles
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
