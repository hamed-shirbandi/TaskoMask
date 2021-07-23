
using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper.MappingActions
{
    public class UserMappingAction : IMappingAction<User, UserInput>, IMappingAction<User, UserOutput>
    {
        private readonly IConfiguration _configuration;
        public UserMappingAction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Process(User source, UserInput destination, ResolutionContext context)
        {
          //  destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }


        public void Process(User source, UserOutput destination, ResolutionContext context)
        {
            //  destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }

    }
}