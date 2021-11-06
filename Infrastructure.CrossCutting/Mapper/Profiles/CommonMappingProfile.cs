using AutoMapper;
using TaskoMask.Application.Core.Dtos.Common.Base;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Mapper.MappingActions;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Mapper.Profiles
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

            #region User

            CreateMap<BaseUser, UserBaseDto>();
            CreateMap<BaseUser, UserBasicInfoDto>()
                 .AfterMap<CommonMappingAction>();      
            CreateMap<BaseUser, UserUpsertDto>();
            CreateMap<UserBaseDto, AuthenticatedUser>();

            #endregion
        }
    }
}