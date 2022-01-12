using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Boards
{
    public abstract class BoardBaseDto
    {
        public string Id { get; set; }


        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get;  set; }


        [StringLength(250, MinimumLength = 5, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get;  set; }


        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string ProjectId { get;  set; }
    }
}
