using AutoMapper;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.Dtos.Administration.Roles;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleBasicInfoDto>();
            CreateMap<Role, RoleUpsertDto>();
            CreateMap<Role, RoleOutputDto>();
            CreateMap<RoleBasicInfoDto, RoleUpsertDto>(); 
        }
    }
}
