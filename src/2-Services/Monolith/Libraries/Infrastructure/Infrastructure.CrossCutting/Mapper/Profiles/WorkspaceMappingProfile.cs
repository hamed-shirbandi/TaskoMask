using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;

namespace TaskoMask.Services.Monolith.Infrastructure.CrossCutting.Mapper.Profiles
{
    public class WorkspaceMappingProfile : Profile
    {
        public WorkspaceMappingProfile()
        {
            #region Task

            CreateMap<Task, TaskBaseDto>();
            CreateMap<Task, GetTaskDto>();
            CreateMap<Task, UpdateTaskDto>();
            CreateMap<GetTaskDto, UpdateTaskDto>();
            CreateMap<Task, GetTaskDto>();


            #endregion

            #region Comments

            CreateMap<Comment, CommentBaseDto>();
            CreateMap<Comment, GetCommentDto>();


            #endregion

            #region Activity

            CreateMap<Activity, GetTaskActivityDto>();


            #endregion

            #region Card

            CreateMap<Card, GetCardDto>();
            CreateMap<Card, UpdateCardDto>();
            CreateMap<GetCardDto, UpdateCardDto>();
            CreateMap<Card, GetCardDto>();

            #endregion

            #region Board

            CreateMap<Board, GetBoardDto>();
            CreateMap<Board, GetBoardDto>();

            #endregion
        }
    }
}
