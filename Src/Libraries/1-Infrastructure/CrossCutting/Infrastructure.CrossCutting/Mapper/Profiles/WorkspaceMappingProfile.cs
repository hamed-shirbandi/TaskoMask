using AutoMapper;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Application.Share.Dtos.Workspace.Activities;
using TaskoMask.Application.Share.Dtos.Workspace.Comments;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class WorkspaceMappingProfile : Profile
    {
        public WorkspaceMappingProfile()
        {
            #region Task

            CreateMap<Task, TaskBaseDto>();
            CreateMap<Task, TaskBasicInfoDto>();
            CreateMap<Task, TaskUpsertDto>();
            CreateMap<TaskBasicInfoDto, TaskUpsertDto>();
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
            CreateMap<Card, CardUpsertDto>();
            CreateMap<CardBasicInfoDto, CardUpsertDto>();
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
            CreateMap<Organization, OrganizationUpsertDto>();
            CreateMap<OrganizationBasicInfoDto, OrganizationUpsertDto>();

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
