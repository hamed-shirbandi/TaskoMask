
using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.MappingActions
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