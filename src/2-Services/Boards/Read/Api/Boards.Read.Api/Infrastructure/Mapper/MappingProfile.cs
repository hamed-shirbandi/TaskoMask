using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Board, GetBoardDto>();
        }
    }
}
