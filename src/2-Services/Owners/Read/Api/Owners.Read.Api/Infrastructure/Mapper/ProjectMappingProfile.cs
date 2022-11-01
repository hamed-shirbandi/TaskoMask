using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, ProjectBasicInfoDto>();
        }
    }
}
