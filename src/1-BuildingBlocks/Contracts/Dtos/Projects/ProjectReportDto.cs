using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Projects
{
   public class ProjectReportDto : BoardReportDto
    {
        [Display(Name = nameof(ContractsMetadata.BoardsCount), ResourceType = typeof(ContractsMetadata))]
        public long BoardsCount { get; set; }

    }
}
