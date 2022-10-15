using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Cards
{
    public class CardReportDto
    {
        [Display(Name = nameof(ContractsMetadata.TasksCount), ResourceType = typeof(ContractsMetadata))]
        public int TasksCount { get; set; }
    }
}
