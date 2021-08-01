using AutoMapper;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {
            #region Dto To Command

            CreateMap<OrganizationInputDto, CreateOrganizationCommand>()
              .ConstructUsing(c => new CreateOrganizationCommand(c.Name, c.Description, c.UserId));

            CreateMap<OrganizationInputDto, UpdateOrganizationCommand>()
              .ConstructUsing(c => new UpdateOrganizationCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateOrganizationCommand, Organization>()
             .ConstructUsing(c => new Organization(c.Name.Trim(), c.Description, c.UserId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<Organization, OrganizationInputDto>();


            #endregion

            #region Dto To Dto

            CreateMap<OrganizationBasicInfoDto, OrganizationInputDto>();


            #endregion
        }
    }
}
