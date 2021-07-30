using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Entities
{
    public class Board: BaseEntity
    {
        public Board(string name, string description, string projectId)
        {
            Name = name;
            Description = description;
            ProjectId = projectId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }

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
