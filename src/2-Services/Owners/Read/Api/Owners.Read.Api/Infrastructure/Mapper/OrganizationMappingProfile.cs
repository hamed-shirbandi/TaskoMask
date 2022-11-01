using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper
{
    public class OrganizationMappingProfile : Profile
    {
        public OrganizationMappingProfile()
        {
            CreateMap<Organization, OrganizationBasicInfoDto>();
        }
    }
}
