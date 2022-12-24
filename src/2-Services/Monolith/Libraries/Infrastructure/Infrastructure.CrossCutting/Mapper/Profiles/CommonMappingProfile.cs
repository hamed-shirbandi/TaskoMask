using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.Profiles
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            #region CreationTime

            CreateMap<CreationTime, CreationTimeDto>()
               .ForMember(dest => dest.CreateDateTimeString, opt =>
                      opt.MapFrom(src => src.CreateDateTime.ToLongDateString()))

               .ForMember(dest => dest.ModifiedDateTimeString, opt =>
                      opt.MapFrom(src => src.ModifiedDateTime.ToLongDateString()));


            #endregion

            #region AuthenticatedUser


            CreateMap<GetOwnerDto, AuthenticatedUserModel>()
                  .ForMember(dest => dest.UserName, opt =>
                      opt.MapFrom(src => src.Email));

            #endregion
        }
    }
}