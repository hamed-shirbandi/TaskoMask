using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Common;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Domain.Core.ValueObjects;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Services.Monolith.Application.Mapper.Profiles
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


            CreateMap<UserBasicInfoDto, AuthenticatedUser>();


            CreateMap<OwnerBasicInfoDto, AuthenticatedUser>()
                  .ForMember(dest => dest.UserName, opt =>
                      opt.MapFrom(src => src.UserInfo.UserName));

            CreateMap<OperatorBasicInfoDto, AuthenticatedUser>()
                  .ForMember(dest => dest.UserName, opt =>
                      opt.MapFrom(src => src.UserInfo.UserName));



            #endregion
        }
    }
}