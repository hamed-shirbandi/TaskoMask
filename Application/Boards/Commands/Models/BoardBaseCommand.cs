using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Boards.Commands.Models
{
    public abstract class BoardBaseCommand : BaseCommand
    {


        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Name { get; protected set; }


        [StringLength(250, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get; protected set; }


        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ProjectId { get; protected set; }
    }
}
