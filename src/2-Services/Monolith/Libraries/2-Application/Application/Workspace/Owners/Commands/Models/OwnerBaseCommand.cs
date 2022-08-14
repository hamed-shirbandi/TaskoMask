using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Share.Helpers;

namespace TaskoMask.Application.Workspace.Owners.Commands.Models
{
    public abstract class OwnerBaseCommand : BaseCommand
    {
        protected OwnerBaseCommand(string id, string displayName, string email)
        {
            DisplayName = displayName;
            Email = email;
            Id = id;
        }


        /// <summary>
        /// use UserId as shared key between User and Owner
        /// </summary>
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }


        [StringLength(DomainConstValues.Owner_DisplayName_Max_Length, MinimumLength = DomainConstValues.Owner_DisplayName_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string DisplayName { get; }
       
        
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        [StringLength(DomainConstValues.Owner_Email_Max_Length, MinimumLength = DomainConstValues.Owner_Email_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [EmailAddress]
        public string Email { get; }

    }
}
