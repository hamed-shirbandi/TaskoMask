using AutoMapper;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Mapper.MappingActions;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Managers;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserBasicInfoDto>()
              .AfterMap<UserMappingAction>();

            CreateMap<User, UserInputDto>()
                .AfterMap<UserMappingAction>();

            CreateMap<UserBasicInfoDto, UserInputDto>();
            CreateMap<UserBasicInfoDto, UserBaseDto>();

            CreateMap<Manager, UserBasicInfoDto>();
            CreateMap<Operator, UserBasicInfoDto>();

            CreateMap<Manager, ManagerBasicInfoDto>();
            CreateMap<Operator, OperatorBasicInfoDto>();
        }
    }
}
