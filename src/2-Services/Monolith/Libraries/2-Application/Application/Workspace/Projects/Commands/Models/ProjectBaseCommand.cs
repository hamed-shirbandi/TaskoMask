using TaskoMask.Services.Monolith.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using TaskoMask.Services.Monolith.Application.Share.Resources;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models
{
    public abstract class ProjectBaseCommand : BaseCommand
    {
        protected ProjectBaseCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }



        [StringLength(DomainConstValues.Project_Name_Max_Length, MinimumLength = DomainConstValues.Project_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; }


        [MaxLength(DomainConstValues.Project_Description_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; }



    }
}
