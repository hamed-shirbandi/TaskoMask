using AutoMapper;
using Microsoft.Extensions.Configuration;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Domain.DomainModel.Membership.Entities;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.MappingActions
{
    /// <summary>
    /// Mapping that needs to inject a dependency goes here
    /// </summary>
    public class MembershipMappingAction : IMappingAction<Operator, OperatorBasicInfoDto>
    {
        private readonly IConfiguration _configuration;
        public MembershipMappingAction(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Process(Operator source, OperatorBasicInfoDto destination, ResolutionContext context)
        {

        }
    }

}