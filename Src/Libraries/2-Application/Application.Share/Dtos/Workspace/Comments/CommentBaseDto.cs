using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Workspace.Comments
{
    public abstract class CommentBaseDto
    {
        public string Id { get; set; }


        [MaxLength(DomainConstValues.Comment_Content_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Content { get; }



        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string TaskId { get; set; }


    }

}
