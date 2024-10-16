using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.Api.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreationTimeDto, CreationTimeGrpcResponse>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.CreateDateTime.ToTimestamp()))
            .ForMember(dest => dest.ModifiedDateTime, opt => opt.MapFrom(src => src.ModifiedDateTime.ToTimestamp()));

        CreateMap<Owner, GetOwnerDto>();

        CreateMap<GetOrganizationReportGrpcResponse, OrganizationReportDto>();

        CreateMap<Organization, GetOrganizationDto>();

        CreateMap<GetBoardGrpcResponse, GetBoardDto>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId ?? string.Empty))
            .ForMember(dest => dest.OrganizationName, opt => opt.MapFrom(src => src.OrganizationName ?? string.Empty))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName ?? string.Empty))
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId ?? string.Empty))
            .ForMember(dest => dest.OrganizationId, opt => opt.MapFrom(src => src.OrganizationId ?? string.Empty));

        CreateMap<CreationTimeGrpcResponse, CreationTimeDto>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => ConvertTimestamp(src.CreateDateTime)))
            .ForMember(dest => dest.CreateDateTimeString, opt => opt.MapFrom(src => src.CreateDateTimeString ?? string.Empty))
            .ForMember(dest => dest.ModifiedDateTime, opt => opt.MapFrom(src => ConvertTimestamp(src.ModifiedDateTime)))
            .ForMember(dest => dest.ModifiedDateTimeString, opt => opt.MapFrom(src => src.ModifiedDateTimeString ?? string.Empty))
            .ForMember(dest => dest.CreateDay, opt => opt.MapFrom(src => src.CreateDay))
            .ForMember(dest => dest.CreateMonth, opt => opt.MapFrom(src => src.CreateMonth))
            .ForMember(dest => dest.CreateYear, opt => opt.MapFrom(src => src.CreateYear));

        CreateMap<GetCardGrpcResponse, GetCardDto>();
        CreateMap<GetTaskGrpcResponse, GetTaskDto>();

        CreateMap<GetOrganizationDto, GetOrganizationGrpcResponse>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty));

        CreateMap<Project, GetProjectDto>();

        CreateMap<GetProjectDto, GetProjectGrpcResponse>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty));
    }

    private DateTime? ConvertTimestamp(Timestamp timestamp)
    {
        try
        {
            return timestamp.ToDateTime();
        }
        catch
        {
            return null;
        }
    }
}
