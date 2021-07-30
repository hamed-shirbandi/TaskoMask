using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Card), ResourceType = typeof(DomainMetadata))]
    public class Card : BaseEntity
    {
        public Card(string name, string description, string boardId,CardType type)
        {
            Name = name;
            Description = description;
            BoardId = boardId;
            Type = type;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public CardType Type { get; set; }
        public string BoardId { get; set; }


        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetType(CardType type)
        {
            Type = type;
        }
    }
}
