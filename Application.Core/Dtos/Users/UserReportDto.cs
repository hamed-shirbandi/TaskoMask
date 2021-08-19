using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Users
{
    public class UserReportDto: TaskReportDto
    {
        [Display(Name = nameof(ApplicationMetadata.OrganizationsCount), ResourceType = typeof(ApplicationMetadata))]
        public int OrganizationsCount { get; set; }
        
        
        [Display(Name = nameof(ApplicationMetadata.ProjectsCount), ResourceType = typeof(ApplicationMetadata))]
        public int ProjectsCount { get; set; }

    }
}
