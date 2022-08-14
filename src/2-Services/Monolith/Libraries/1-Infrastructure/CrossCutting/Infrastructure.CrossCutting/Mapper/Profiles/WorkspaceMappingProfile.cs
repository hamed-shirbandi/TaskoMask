using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Comments;

namespace TaskoMask.Services.Monolith.Application.Mapper.Profiles
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
            CreateMap<Project, ProjectOutputDto>();

            #endregion

            #region Owner

            CreateMap<Owner, OwnerBasicInfoDto>();
            CreateMap<Owner, OwnerOutputDto>();


            #endregion
        }
    }
}
