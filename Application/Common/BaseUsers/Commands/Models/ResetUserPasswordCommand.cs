using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.BaseUsers.Commands.Models
{
    public class ResetUserPasswordCommand<TEntity> : BaseCommand where TEntity : BaseUser
    {
        public ResetUserPasswordCommand(string id, string newPassword)
        {
            Id = id;
            NewPassword = newPassword;
        }


        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; set; }


        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string NewPassword { get; set; }



    }
}
