using AutoMapper;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Domain.Team.Entities.Members;

namespace TaskoMask.Application.Mapper.Profiles
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            #region Organization

            CreateMap<Organization, OrganizationBasicInfoDto>();
            CreateMap<Organization, OrganizationUpsertDto>();
            CreateMap<OrganizationBasicInfoDto, OrganizationUpsertDto>();
            CreateMap<Organization, OrganizationOutputDto>();

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
