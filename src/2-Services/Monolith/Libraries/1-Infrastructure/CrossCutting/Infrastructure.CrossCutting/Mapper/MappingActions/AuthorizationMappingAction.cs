using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Entities;

namespace TaskoMask.Services.Monolith.Application.Mapper.MappingActions
{
    /// <summary>
    /// Mapping that needs to inject a dependency goes here
    /// </summary>
    public class AuthorizationMappingAction : IMappingAction<User, UserBasicInfoDto>
    {
        private readonly IConfiguration _configuration;
        public AuthorizationMappingAction(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Process(User source, UserBasicInfoDto destination, ResolutionContext context)
        {
            
        }
    }

}