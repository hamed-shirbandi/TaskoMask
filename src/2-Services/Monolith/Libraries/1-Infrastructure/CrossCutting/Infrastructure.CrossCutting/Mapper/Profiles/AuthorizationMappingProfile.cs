using AutoMapper;
using TaskoMask.Application.Share.Dtos.Common;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Application.Mapper.MappingActions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Models;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class AuthorizationMappingProfile : Profile
    {
        public AuthorizationMappingProfile()
        {
            #region User

            CreateMap<User, UserBasicInfoDto>();

            #endregion
        }
    }
}