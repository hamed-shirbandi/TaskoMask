using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Card : BaseEntity
    {
        public Card(string name, string description, string boardId)
        {
            Name = name;
            Description = description;
            BoardId = boardId;
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
    }
}
