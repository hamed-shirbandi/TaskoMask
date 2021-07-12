using AutoMapper;
using TaskoMask.Application.Commands.Models.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {
            #region Dto To Command

            CreateMap<OrganizationInput, CreateOrganizationCommand>()
              .ConstructUsing(c => new CreateOrganizationCommand(c.Name, c.Description, c.UserId));

            CreateMap<OrganizationInput, UpdateOrganizationCommand>()
              .ConstructUsing(c => new UpdateOrganizationCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateOrganizationCommand, Organization>()
             .ConstructUsing(c => new Organization(c.Name.Trim(), c.Description, c.UserId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Organization, OrganizationOutput>();
            CreateMap<Organization, OrganizationInput>();


            #endregion

            #region Dto To Dto

            CreateMap<OrganizationOutput, OrganizationInput>();


            #endregion
        }
    }
}
