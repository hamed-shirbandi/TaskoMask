using AutoMapper;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            #region Dto To Command

            CreateMap<ProjectInput, CreateProjectCommand>()
              .ConstructUsing(c => new CreateProjectCommand(c.Name, c.Description, c.OrganizationId));

            CreateMap<ProjectInput, UpdateProjectCommand>()
              .ConstructUsing(c => new UpdateProjectCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateProjectCommand, Project>()
             .ConstructUsing(c => new Project(c.Name.Trim(), c.Description, c.OrganizationId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Project, ProjectOutput>();
            CreateMap<Project, ProjectInput>();


            #endregion

            #region Dto To Dto

            CreateMap<ProjectOutput, ProjectInput>();


            #endregion

        }
    }
}
