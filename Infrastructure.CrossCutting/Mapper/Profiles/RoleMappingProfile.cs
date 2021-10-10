using AutoMapper;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Domain.Administration.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleBasicInfoDto>();
            CreateMap<Role, RoleInputDto>();
            CreateMap<RoleBasicInfoDto, RoleInputDto>();
        }
    }
}
