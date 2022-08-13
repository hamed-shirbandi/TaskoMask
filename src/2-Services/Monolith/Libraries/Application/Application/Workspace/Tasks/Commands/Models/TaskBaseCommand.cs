﻿using TaskoMask.Application.Core.Commands;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Tasks.Commands.Models
{
    public abstract class TaskBaseCommand : BaseCommand
    {
        protected TaskBaseCommand(string title, string description )
        {
            Title = title;
            Description = description;
        }


        [StringLength(DomainConstValues.Task_Title_Max_Length, MinimumLength = DomainConstValues.Task_Title_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Title { get; }


        [MaxLength(DomainConstValues.Task_Description_Max_Length, ErrorMessageResourceName = nameof(DomainMessages.Max_Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Description { get; }



    }
}
