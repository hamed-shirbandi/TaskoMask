using AutoMapper;
using TaskoMask.Application.Core.Dtos;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<CreationTime, CreationTimeDto>()
              .ForMember(dest => dest.CreateDateTimeString, opt =>
                     opt.MapFrom(src => src.CreateDateTime.ToLongDateString()))

              .ForMember(dest => dest.ModifiedDateTimeString, opt =>
                     opt.MapFrom(src => src.ModifiedDateTime.ToLongDateString()));

        }
    }
}
