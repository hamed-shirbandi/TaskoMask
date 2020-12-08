using AutoMapper;
using TaskoMask.Application.Commands.Models.Boards;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {
            #region Dto To Command

            CreateMap<BoardInput, CreateBoardCommand>()
              .ConstructUsing(c => new CreateBoardCommand(c.Name, c.Description, c.ProjectId));

            CreateMap<BoardInput, UpdateBoardCommand>()
              .ConstructUsing(c => new UpdateBoardCommand(c.Id, c.Name, c.Description));


            #endregion

            #region Command To Domain Model

            CreateMap<CreateBoardCommand, Board>()
             .ConstructUsing(c => new Board(c.Name.Trim(), c.Description, c.ProjectId));

            #endregion

            #region Domain Model To Dto

            CreateMap<Board, BoardOutput>();
            CreateMap<Board, BoardInput>();


            #endregion

            #region Dto To Dto

            CreateMap<BoardOutput, BoardInput>();


            #endregion

        }
    }
}
