using AutoMapper;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {
            #region Dto To Command

            CreateMap<BoardInputDto, CreateBoardCommand>()
              .ConstructUsing(c => new CreateBoardCommand(c.Name, c.Description, c.ProjectId));

            CreateMap<BoardInputDto, UpdateBoardCommand>()
              .ConstructUsing(c => new UpdateBoardCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateBoardCommand, Board>()
             .ConstructUsing(c => new Board(c.Name.Trim(), c.Description, c.ProjectId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Board, BoardOutput>();
            CreateMap<Board, BoardInputDto>();


            #endregion

            #region Dto To Dto

            CreateMap<BoardOutput, BoardInputDto>();


            #endregion

        }
    }
}
