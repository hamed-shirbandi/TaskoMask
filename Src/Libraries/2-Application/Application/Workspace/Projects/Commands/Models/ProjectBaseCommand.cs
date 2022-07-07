using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Workspace.Projects.Commands.Models
{
    public abstract class ProjectBaseCommand : BaseCommand
    {
        protected ProjectBaseCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }



        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Project_Name_Max_Length, MinimumLength = DomainConstValues.Project_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; }


        [Display(Name = nameof(ApplicationMetadata.Description), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Project_Name_Max_Length, MinimumLength = DomainConstValues.Project_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; }



    }
}
