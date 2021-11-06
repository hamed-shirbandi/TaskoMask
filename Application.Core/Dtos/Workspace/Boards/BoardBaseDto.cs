using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Workspace.Boards
{
    public abstract class BoardBaseDto
    {
        public string Id { get; set; }


        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Name { get;  set; }


        [StringLength(250, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Description { get;  set; }


        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string ProjectId { get;  set; }
    }
}
