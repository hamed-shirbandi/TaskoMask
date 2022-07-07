using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Boards.Commands.Models
{
    public abstract class BoardBaseCommand : BaseCommand
    {
        protected BoardBaseCommand(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }


        [StringLength(DomainConstValues.Board_Name_Max_Length, MinimumLength = DomainConstValues.Board_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; }


        [StringLength(DomainConstValues.Board_Description_Max_Length, MinimumLength = DomainConstValues.Board_Description_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; }


        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string ProjectId { get; }

    }
}
