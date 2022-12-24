using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
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
            CreateMap<CreationTimeDto, CreationTimeGrpcResponse>()
             .ForMember(dest => dest.CreateDateTime, opt =>
                  opt.MapFrom(src => src.CreateDateTime.ToTimestamp()))
            .ForMember(dest => dest.ModifiedDateTime, opt =>
                  opt.MapFrom(src => src.ModifiedDateTime.ToTimestamp()));

            CreateMap<Owner, GetOwnerDto>();

            CreateMap<Organization, GetOrganizationDto>();

            CreateMap<GetOrganizationDto, GetOrganizationGrpcResponse>()
            .ForMember(dest => dest.Description, opt =>
                  opt.MapFrom(src => src.Description ?? string.Empty));

            CreateMap<Project, GetProjectDto>();

            CreateMap<GetProjectDto, GetProjectGrpcResponse>()
            .ForMember(dest => dest.Description, opt =>
                  opt.MapFrom(src => src.Description ?? string.Empty));
        }
    }
}
