using AutoMapper;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<Project, ProjectUpsertDto>();
            CreateMap<ProjectBasicInfoDto, ProjectUpsertDto>();
        }
    }
}
