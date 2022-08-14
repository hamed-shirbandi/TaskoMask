using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Organizations
{
   public class OrganizationReportDto : ProjectReportDto
    {
        [Display(Name = nameof(ContractsMetadata.ProjectsCount), ResourceType = typeof(ContractsMetadata))]
        public long ProjectsCount { get; set; }

    }
}
