using TaskoMask.Services.Monolith.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;

namespace TaskoMask.Services.Monolith.Application.Workspace.Comments.Commands.Models
{

    public abstract class CommentBaseCommand : BaseCommand
    {

        protected CommentBaseCommand(string content )
        {
            Content = content;
        }


        [MaxLength(DomainConstValues.Comment_Content_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Content { get; }


    }
}
