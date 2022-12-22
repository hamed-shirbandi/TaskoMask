using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.Services.Boards.Read.Api.Domain;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using Google.Protobuf.WellKnownTypes;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Board, GetBoardDto>();

            CreateMap<CreationTimeDto, CreationTime>()
                 .ForMember(dest => dest.CreateDateTime, opt =>
                      opt.MapFrom(src => src.CreateDateTime.ToTimestamp()))
                 .ForMember(dest => dest.ModifiedDateTime, opt =>
                      opt.MapFrom(src => src.ModifiedDateTime.ToTimestamp()));


            CreateMap<GetBoardDto, GetBoardByIdGrpcResponse>()
            .ForMember(dest => dest.Description, opt =>
                  opt.MapFrom(src => src.Description ?? string.Empty));
        }
    }
}
