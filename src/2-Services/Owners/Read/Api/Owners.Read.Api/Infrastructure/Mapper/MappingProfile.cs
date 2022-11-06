using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Owner, OwnerBasicInfoDto>();

            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<OrganizationBasicInfoDto, OrganizationBasicInfoGrpcResponse>();

            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<ProjectBasicInfoDto, ProjectBasicInfoGrpcResponse>();
        }
    }
}
