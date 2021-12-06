using AutoMapper;
using TaskoMask.Application.Share.Dtos.Administration.Operators;
using TaskoMask.Application.Share.Dtos.Administration.Permissions;
using TaskoMask.Application.Share.Dtos.Administration.Roles;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class AdministrationMappingProfile : Profile
    {
        public AdministrationMappingProfile()
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
            CreateMap<Operator, OperatorUpsertDto>();
            CreateMap<Operator, OperatorOutputDto>();

            #endregion

        }
    }
}
