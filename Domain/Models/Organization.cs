using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Organization : BaseEntity
    {
        public Organization(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }

        public string  Name { get; private set; }
        public string  Description { get; private set; }
        public string UserId { get; private set; }
    }
}
