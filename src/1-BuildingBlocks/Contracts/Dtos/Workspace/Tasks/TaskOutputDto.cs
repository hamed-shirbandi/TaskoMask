using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Tasks
{
    public class TaskOutputDto: TaskBasicInfoDto
    {
        [Display(Name = nameof(ContractsMetadata.OrganizationName), ResourceType = typeof(ContractsMetadata))]
        public string CardName { get; set; }
    }
}
