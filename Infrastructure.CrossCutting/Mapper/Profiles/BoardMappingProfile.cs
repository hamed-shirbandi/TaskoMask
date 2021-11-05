using AutoMapper;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Domain.TaskManagement.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {
            CreateMap<Board, BoardBasicInfoDto>();
            CreateMap<Board, BoardUpsertDto>();
            CreateMap<BoardBasicInfoDto, BoardUpsertDto>();
        }
    }
}
