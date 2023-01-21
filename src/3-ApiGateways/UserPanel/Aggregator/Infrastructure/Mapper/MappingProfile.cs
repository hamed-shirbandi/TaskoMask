using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Common;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreationTimeGrpcResponse,  CreationTimeDto> ()
                 .ForMember(dest => dest.CreateDateTime, opt =>
                      opt.MapFrom(src => src.CreateDateTime.ToDateTime()))
                .ForMember(dest => dest.ModifiedDateTime, opt =>
                      opt.MapFrom(src => src.ModifiedDateTime.ToDateTime()));

            CreateMap<GetOrganizationGrpcResponse, GetOrganizationDto>();

            CreateMap<GetProjectGrpcResponse, GetProjectDto>();

            CreateMap<GetBoardGrpcResponse, GetBoardDto>();

            CreateMap<GetCardGrpcResponse, GetCardDto>();
        }
    }
}
