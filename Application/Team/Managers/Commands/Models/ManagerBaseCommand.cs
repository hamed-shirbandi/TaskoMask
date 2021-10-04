using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Team.Managers.Commands.Models
{
    public abstract class ManagerBaseCommand : BaseCommand
    {
      
        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string DisplayName { get; protected set; }
       
        
        [StringLength(50, MinimumLength = 5, ErrorMessageResourceName = nameof(ApplicationMetadata.Length_Error), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Email { get; protected set; }
      
        
        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Password { get; protected set; }
    }
}
