using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards
{
    public class CardOutputDto : CardBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.BoardName), ResourceType = typeof(ContractsMetadata))]
        public string BoardName { get; set; }

        [Display(Name = nameof(ContractsMetadata.TasksCount), ResourceType = typeof(ContractsMetadata))]
        public long TasksCount { get; set; }
    }
}
