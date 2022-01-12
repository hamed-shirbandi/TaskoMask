using AutoMapper;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Domain.Workspace.Boards.Entities;
using TaskoMask.Domain.Workspace.Members.Entities;
using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Domain.Workspace.Tasks.Entities;

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


            #region Organization

            CreateMap<Organization, OrganizationBaseDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value))
                    .ForMember(dest => dest.OwnerMemberId, opt => opt.MapFrom(src => src.OwnerMemberId.Value));

            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<Organization, OrganizationOutputDto>();
            CreateMap<Organization, OrganizationUpsertDto>();
            CreateMap<OrganizationBasicInfoDto, OrganizationUpsertDto>();

            #endregion

            #region Project

            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<Project, ProjectUpsertDto>();
            CreateMap<ProjectBasicInfoDto, ProjectUpsertDto>();
            CreateMap<Project, ProjectOutputDto>();

            #endregion

            #region Member

            CreateMap<Member, MemberBasicInfoDto>();
            CreateMap<Member, MemberOutputDto>();


            #endregion
        }
    }
}
