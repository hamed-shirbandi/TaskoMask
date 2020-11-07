using AutoMapper;
using TaskoMask.Application.Commands.Models.Organizations;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrganizationInput, CreateOrganizationCommand>()
               .ConstructUsing(c => new CreateOrganizationCommand(c.Name, c.Description, c.UserId));
            CreateMap<CreateOrganizationCommand, Organization>()
              .ConstructUsing(c => new Organization(c.Name, c.Description, c.UserId));
            CreateMap<OrganizationInput, CreateOrganizationCommand>()
              .ConstructUsing(c => new CreateOrganizationCommand(c.Name, c.Description, c.UserId));
            CreateMap<CreateOrganizationCommand, Organization>()
              .ConstructUsing(c => new Organization(c.Name, c.Description, c.UserId));
            CreateMap<Organization, OrganizationOutput>();
            CreateMap<Organization, OrganizationInput>();



            CreateMap<ProjectInput, CreateProjectCommand>()
              .ConstructUsing(c => new CreateProjectCommand(c.Name, c.Description, c.OrganizationId));
            CreateMap<CreateProjectCommand, Project>()
              .ConstructUsing(c => new Project(c.Name, c.Description, c.OrganizationId));
            CreateMap<ProjectInput, CreateProjectCommand>()
              .ConstructUsing(c => new CreateProjectCommand(c.Name, c.Description, c.OrganizationId));
            CreateMap<CreateProjectCommand, Project>()
              .ConstructUsing(c => new Project(c.Name, c.Description, c.OrganizationId));
            CreateMap<Project, ProjectOutput>();
            CreateMap<Project, ProjectInput>();



        }
    }
}
