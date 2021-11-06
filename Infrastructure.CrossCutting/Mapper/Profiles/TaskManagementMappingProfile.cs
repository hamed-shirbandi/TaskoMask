using AutoMapper;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.Dtos.TaskManagement.Cards;
using TaskoMask.Application.Core.Dtos.TaskManagement.Tasks;
using TaskoMask.Domain.TaskManagement.Entities;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class TaskManagementMappingProfile : Profile
    {
        public TaskManagementMappingProfile()
        {
            #region Task

            CreateMap<Task, TaskBasicInfoDto>();
            CreateMap<Task, TaskUpsertDto>();
            CreateMap<TaskBasicInfoDto, TaskUpsertDto>();


            #endregion

            #region Card

            CreateMap<Card, CardBasicInfoDto>();
            CreateMap<Card, CardUpsertDto>();
            CreateMap<CardBasicInfoDto, CardUpsertDto>();

            #endregion

            #region Board

            CreateMap<Board, BoardBasicInfoDto>();
            CreateMap<Board, BoardUpsertDto>();
            CreateMap<BoardBasicInfoDto, BoardUpsertDto>();

            #endregion
        }
    }
}
