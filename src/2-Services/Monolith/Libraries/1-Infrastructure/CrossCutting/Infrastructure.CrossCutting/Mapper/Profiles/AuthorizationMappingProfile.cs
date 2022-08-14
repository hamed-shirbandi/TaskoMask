using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Common;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Application.Mapper.MappingActions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Services.Monolith.Application.Mapper.Profiles
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