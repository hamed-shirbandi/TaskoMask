using AutoMapper;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Share.Dtos.Common;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.Share.Models;
using TaskoMask.Domain.WriteModel.Authorization.Entities;

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

            #region AuthenticatedUser


            CreateMap<OwnerBasicInfoDto, AuthenticatedUser>()
                  .ForMember(dest => dest.UserName, opt =>
                      opt.MapFrom(src => src.UserInfo.UserName))
                   .ForMember(dest => dest.Type, opt =>
                      opt.MapFrom(src => src.UserInfo.Type));

            CreateMap<OperatorBasicInfoDto, AuthenticatedUser>()
                  .ForMember(dest => dest.UserName, opt =>
                      opt.MapFrom(src => src.UserInfo.UserName))
                   .ForMember(dest => dest.Type, opt =>
                      opt.MapFrom(src => src.UserInfo.Type));

            CreateMap<UserBasicInfoDto, AuthenticatedUser>() ;


            #endregion
        }
    }
}