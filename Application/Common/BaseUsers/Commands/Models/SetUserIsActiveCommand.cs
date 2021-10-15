using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.BaseUsers.Commands.Models
{
    public class SetUserIsActiveCommand<TEntity> : BaseCommand where TEntity : BaseUser
    {

        public SetUserIsActiveCommand(string id, bool isActive)
        {
            Id = id;
            IsActive = isActive;
        }


        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; set; }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public bool IsActive { get; set; }


    }
}
