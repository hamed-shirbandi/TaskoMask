using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard
{
    public class DeleteBoardRequest: BaseCommand
    {
        public DeleteBoardRequest(string id)
        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }

    }
}
