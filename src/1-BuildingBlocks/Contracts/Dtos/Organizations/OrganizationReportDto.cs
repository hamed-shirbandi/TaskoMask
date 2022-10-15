using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations
{
   public class OrganizationReportDto : ProjectReportDto
    {
        [Display(Name = nameof(ContractsMetadata.ProjectsCount), ResourceType = typeof(ContractsMetadata))]
        public long ProjectsCount { get; set; }

    }
}
