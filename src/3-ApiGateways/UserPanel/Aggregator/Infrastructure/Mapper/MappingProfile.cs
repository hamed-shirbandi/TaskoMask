using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrganizationBasicInfoGrpcResponse, OrganizationBasicInfoDto>();

            CreateMap<GetProjectsByOrganizationIdGrpcRequest, ProjectBasicInfoDto>();

            CreateMap<ProjectBasicInfoGrpcResponse, ProjectBasicInfoDto>();
        }
    }
}
