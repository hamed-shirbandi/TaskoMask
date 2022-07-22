using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Share.Helpers;

namespace TaskoMask.Application.Workspace.Comments.Commands.Models
{

    public abstract class CommentBaseCommand : BaseCommand
    {

        protected CommentBaseCommand(string content )
        {
            Content = content;
        }


        [MaxLength(DomainConstValues.Comment_Content_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Content { get; }


    }
}
