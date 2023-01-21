using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Tasks.Write.Application.UseCases.Tasks.UpdateTask
{
    public class UpdateTaskRequest : BaseCommand
    {
        public UpdateTaskRequest(string id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Id { get; }


        [StringLength(DomainConstValues.Task_Title_Max_Length, MinimumLength = DomainConstValues.Task_Title_Min_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        [Required(ErrorMessageResourceName = nameof(ContractsMetadata.Required), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Title { get; }


        [MaxLength(DomainConstValues.Task_Description_Max_Length, ErrorMessageResourceName = nameof(ContractsMetadata.Max_Length_Error), ErrorMessageResourceType = typeof(ContractsMetadata))]
        public string Description { get; }


    }
}
