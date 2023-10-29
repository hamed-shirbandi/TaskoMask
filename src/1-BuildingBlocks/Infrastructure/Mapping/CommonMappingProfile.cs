using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;

namespace TaskoMask.BuildingBlocks.Infrastructure.Mapping;

public class CommonMappingProfile : Profile
{
    public CommonMappingProfile()
    {
        CreateMap<CreationTime, CreationTimeDto>()
            .ForMember(dest => dest.CreateDateTimeString, opt => opt.MapFrom(src => src.CreateDateTime.ToLongDateString()))
            .ForMember(dest => dest.ModifiedDateTimeString, opt => opt.MapFrom(src => src.ModifiedDateTime.ToLongDateString()));
    }
}
