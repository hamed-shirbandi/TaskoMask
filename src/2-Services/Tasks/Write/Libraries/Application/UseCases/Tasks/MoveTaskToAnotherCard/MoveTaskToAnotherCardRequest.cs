using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.MoveTaskToAnotherCard
{
    public class MoveTaskToAnotherCardRequest : BaseCommand
    {
        public MoveTaskToAnotherCardRequest(string taskId, string cardId)
        {
            TaskId = taskId;
            CardId = cardId;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string TaskId { get; }


        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string CardId { get; }


    }
}
