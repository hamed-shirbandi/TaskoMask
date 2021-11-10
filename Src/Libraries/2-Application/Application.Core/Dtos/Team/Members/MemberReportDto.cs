using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Team.Members
{
    public class MemberReportDto : OrganizationReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationsCount), ResourceType = typeof(ApplicationMetadata))]
        public int OrganizationsCount { get; set; }
       
    }
}
