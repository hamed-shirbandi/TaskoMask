using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Boards.Commands.Models
{
    public abstract class BoardBaseCommand : BaseCommand
    {
        protected BoardBaseCommand(string name, string description )
        {
            Name = name;
            Description = description;
        }


        [StringLength(DomainConstValues.Board_Name_Max_Length, MinimumLength = DomainConstValues.Board_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; }


        [MaxLength(DomainConstValues.Board_Description_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; }




    }
}
