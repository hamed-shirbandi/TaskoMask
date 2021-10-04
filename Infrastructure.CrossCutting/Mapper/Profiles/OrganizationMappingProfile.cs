using AutoMapper;
using TaskoMask.Application.Core.Dtos.Organizations;


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
