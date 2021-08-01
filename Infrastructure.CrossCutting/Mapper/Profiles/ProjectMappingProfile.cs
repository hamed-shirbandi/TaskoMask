using AutoMapper;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            #region Dto To Command

            CreateMap<ProjectInputDto, CreateProjectCommand>()
              .ConstructUsing(c => new CreateProjectCommand(c.Name, c.Description, c.OrganizationId));

            CreateMap<ProjectInputDto, UpdateProjectCommand>()
              .ConstructUsing(c => new UpdateProjectCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateProjectCommand, Project>()
             .ConstructUsing(c => new Project(c.Name.Trim(), c.Description, c.OrganizationId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<Project, ProjectInputDto>();


            #endregion

            #region Dto To Dto

            CreateMap<ProjectBasicInfoDto, ProjectInputDto>();


            #endregion

        }
    }
}
