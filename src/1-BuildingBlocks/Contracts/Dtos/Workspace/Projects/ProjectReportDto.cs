using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects
{
   public class ProjectReportDto : BoardReportDto
    {
        [Display(Name = nameof(ContractsMetadata.BoardsCount), ResourceType = typeof(ContractsMetadata))]
        public long BoardsCount { get; set; }

    }
}
