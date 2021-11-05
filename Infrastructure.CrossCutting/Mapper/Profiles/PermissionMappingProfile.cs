using AutoMapper;
using TaskoMask.Application.Core.Dtos.Administration.Permissions;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<Permission, PermissionBasicInfoDto>();
            CreateMap<Permission, PermissionUpsertDto>();
            CreateMap<Permission, PermissionOutputDto>();
            CreateMap<PermissionBasicInfoDto, PermissionUpsertDto>();
        }
    }
}
