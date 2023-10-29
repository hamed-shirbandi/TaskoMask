using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreationTimeDto, CreationTimeGrpcResponse>()
            .ForMember(dest => dest.CreateDateTime, opt => opt.MapFrom(src => src.CreateDateTime.ToTimestamp()))
            .ForMember(dest => dest.ModifiedDateTime, opt => opt.MapFrom(src => src.ModifiedDateTime.ToTimestamp()));

        CreateMap<GetProjectGrpcResponse, GetProjectDto>();

        CreateMap<Board, GetBoardDto>();

        CreateMap<GetBoardDto, GetBoardGrpcResponse>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty));

        CreateMap<Card, GetCardDto>();

        CreateMap<GetCardDto, GetCardGrpcResponse>();
    }
}
