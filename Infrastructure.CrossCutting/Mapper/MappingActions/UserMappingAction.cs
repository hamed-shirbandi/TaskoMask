
using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.MappingActions
{
    public class UserMappingAction : IMappingAction<User, UserInputDto>, IMappingAction<User, UserBasicInfoDto>
    {
        private readonly IConfiguration _configuration;
        public UserMappingAction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Process(User source, UserInputDto destination, ResolutionContext context)
        {
            destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }


        public void Process(User source, UserBasicInfoDto destination, ResolutionContext context)
        {
              destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }

    }
}