
using AutoMapper;
using AutoMapper.Configuration;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Domain.ReadModel.Entities;

namespace TaskoMask.Application.Mapper.MappingActions
{
    /// <summary>
    /// Mapping that needs to inject a dependency goes here
    /// </summary>
    public class WorkspaceMappingAction : IMappingAction<Owner, OwnerBasicInfoDto>
    {
        private readonly IConfiguration _configuration;
        public WorkspaceMappingAction(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Process(Owner source, OwnerBasicInfoDto destination, ResolutionContext context)
        {
            //for example
            //destination.AvatarUrl = source.AvatarUrl.AddStaticSiteUrl(_configuration);
        }
    }
}