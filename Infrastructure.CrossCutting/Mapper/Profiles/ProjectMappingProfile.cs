using AutoMapper;
using TaskoMask.Application.Core.Dtos.Projects;


namespace TaskoMask.Application.Mapper.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<Project, ProjectInputDto>();
            CreateMap<ProjectBasicInfoDto, ProjectInputDto>();
        }
    }
}
