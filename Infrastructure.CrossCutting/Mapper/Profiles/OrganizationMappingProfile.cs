using AutoMapper;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {

            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<Organization, OrganizationUpsertDto>();
            CreateMap<OrganizationBasicInfoDto, OrganizationUpsertDto>();

        }
    }
}
