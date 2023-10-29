using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Tasks.Write.Api.UseCases.Tasks.DeleteTask;

public class DeleteTaskRequest : BaseCommand
{
    public DeleteTaskRequest(string id)
    {
        Id = id;
    }

    [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
    public string Id { get; }
}
