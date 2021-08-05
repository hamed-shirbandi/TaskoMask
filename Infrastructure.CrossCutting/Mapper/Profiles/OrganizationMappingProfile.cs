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

            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<Organization, OrganizationInputDto>();
            CreateMap<OrganizationBasicInfoDto, OrganizationInputDto>();

        }
    }
}
