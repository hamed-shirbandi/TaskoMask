

using AutoMapper;
using AutoMapper.Configuration;
using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Domain.WriteModel.Membership.Entities;

namespace TaskoMask.Application.Mapper.MappingActions
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