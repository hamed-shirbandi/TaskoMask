using AutoMapper;
using TaskoMask.Application.Core.Dtos.Permissions;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<Permission, PermissionBasicInfoDto>();
            CreateMap<Permission, PermissionInputDto>();
            CreateMap<Permission, PermissionOutputDto>();
            CreateMap<PermissionBasicInfoDto, PermissionInputDto>();
        }
    }
}
