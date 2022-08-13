﻿using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Application.Workspace.Cards.Commands.Models
{
    public class UpdateCardCommand : CardBaseCommand
    {
        public UpdateCardCommand(string id, string name , BoardCardType type)
                : base(name, type)

        {
            Id = id;
        }

        [Required(ErrorMessageResourceName = nameof(DomainMessages.Required), ErrorMessageResourceType = typeof(DomainMessages))]
        public string Id { get; }
    }
}
