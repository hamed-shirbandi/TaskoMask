using AutoMapper;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Domain.Team.Entities;

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

            #endregion

            #region Project

            CreateMap<Project, ProjectBasicInfoDto>();
            CreateMap<Project, ProjectUpsertDto>();
            CreateMap<ProjectBasicInfoDto, ProjectUpsertDto>();

            #endregion

            #region Member

            CreateMap<Member, MemberBasicInfoDto>();


            #endregion
        }
    }
}
