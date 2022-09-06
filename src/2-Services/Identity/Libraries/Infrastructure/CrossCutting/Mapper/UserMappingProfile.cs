using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Infrastructure.CrossCutting.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserBasicInfoDto>();
        }
    }
}