using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Owners
{
    public class OwnerReportDto : OrganizationReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationsCount), ResourceType = typeof(ApplicationMetadata))]
        public int OrganizationsCount { get; set; }
       
    }
}
