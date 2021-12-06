using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Team.Members
{
    public class MemberReportDto : OrganizationReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationsCount), ResourceType = typeof(ApplicationMetadata))]
        public int OrganizationsCount { get; set; }
       
    }
}
