﻿using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Share.Enums;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Share.Helpers;

namespace TaskoMask.Application.Workspace.Cards.Commands.Models
{

    public abstract class CardBaseCommand : BaseCommand
    {

        protected CardBaseCommand(string name , BoardCardType type)
        {
            Name = name;
            Type = type;
        }


        [Display(Name = nameof(ApplicationMetadata.Name), ResourceType = typeof(ApplicationMetadata))]
        [StringLength(DomainConstValues.Card_Name_Max_Length, MinimumLength = DomainConstValues.Card_Name_Min_Length, ErrorMessageResourceName = nameof(DomainMessages.Length_Error), ErrorMessageResourceType = typeof(DomainMessages))]
        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Name { get; }


        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public BoardCardType Type { get; }
    }
}
