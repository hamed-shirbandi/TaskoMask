using AutoMapper;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {
            CreateMap<Board, BoardBasicInfoDto>();
            CreateMap<Board, BoardInputDto>();
            CreateMap<BoardBasicInfoDto, BoardInputDto>();
        }
    }
}
