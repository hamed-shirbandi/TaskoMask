using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper
{
    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile()
        {
            CreateMap<Owner, OwnerBasicInfoDto>();
        }
    }
}
