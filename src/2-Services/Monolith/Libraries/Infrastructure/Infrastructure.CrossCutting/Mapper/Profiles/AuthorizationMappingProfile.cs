using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.MappingActions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Domain.ValueObjects;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.Profiles
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