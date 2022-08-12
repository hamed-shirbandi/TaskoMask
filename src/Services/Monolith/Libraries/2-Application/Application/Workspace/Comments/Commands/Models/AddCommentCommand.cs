﻿using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Comments.Commands.Models
{
    public class AddCommentCommand : CommentBaseCommand
    {
        public AddCommentCommand(string taskId , string content)
                : base(content)
        {
            TaskId = taskId;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string TaskId { get; }
    }
}
