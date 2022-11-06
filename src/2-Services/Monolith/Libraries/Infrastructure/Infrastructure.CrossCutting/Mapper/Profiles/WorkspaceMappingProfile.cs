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
            CreateMap<Task, TaskBasicInfoDto>();
            CreateMap<Task, UpdateTaskDto>();
            CreateMap<TaskBasicInfoDto, UpdateTaskDto>();
            CreateMap<Task, TaskOutputDto>();


            #endregion

            #region Comments

            CreateMap<Comment, CommentBaseDto>();
            CreateMap<Comment, CommentBasicInfoDto>();


            #endregion

            #region Activity

            CreateMap<Activity, ActivityBaseDto>();
            CreateMap<Activity, ActivityBasicInfoDto>();


            #endregion

            #region Card

            CreateMap<Card, CardBasicInfoDto>();
            CreateMap<Card, UpdateCardDto>();
            CreateMap<CardBasicInfoDto, UpdateCardDto>();
            CreateMap<Card, CardOutputDto>();

            #endregion

            #region Board

            CreateMap<Board, BoardBasicInfoDto>();
            CreateMap<Board, BoardOutputDto>();

            #endregion

            #region Organization

            CreateMap<Organization, OrganizationBaseDto>();
            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<Organization, OrganizationOutputDto>();

            #endregion

            #region Project

            CreateMap<Project, ProjectBasicInfoDto>();

            #endregion

            #region Owner

            CreateMap<Owner, OwnerBasicInfoDto>();
            CreateMap<Owner, OwnerOutputDto>();


            #endregion
        }
    }
}
