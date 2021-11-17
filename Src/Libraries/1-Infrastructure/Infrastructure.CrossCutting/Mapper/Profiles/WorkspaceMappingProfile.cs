using AutoMapper;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Dtos.Workspace.Tasks;
using TaskoMask.Domain.Workspace.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class WorkspaceMappingProfile : Profile
    {
        public WorkspaceMappingProfile()
        {
            #region Task

            CreateMap<Task, TaskBasicInfoDto>();
            CreateMap<Task, TaskUpsertDto>();
            CreateMap<TaskBasicInfoDto, TaskUpsertDto>();
            CreateMap<Task, TaskOutputDto>();


            #endregion

            #region Card

            CreateMap<Card, CardBasicInfoDto>();
            CreateMap<Card, CardUpsertDto>();
            CreateMap<CardBasicInfoDto, CardUpsertDto>();
            CreateMap<Card, CardOutputDto>();

            #endregion

            #region Board

            CreateMap<Board, BoardBasicInfoDto>();
            CreateMap<Board, BoardUpsertDto>();
            CreateMap<BoardBasicInfoDto, BoardUpsertDto>();
            CreateMap<Board, BoardOutputDto>();

            #endregion
        }
    }
}
