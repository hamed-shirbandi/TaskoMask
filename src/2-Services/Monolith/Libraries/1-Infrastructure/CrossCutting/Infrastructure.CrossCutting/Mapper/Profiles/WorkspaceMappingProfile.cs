using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Activities;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Comments;

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
