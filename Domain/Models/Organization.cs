using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Organization : BaseEntity
    {
        public string  Name { get; set; }
        public string  Description { get; set; }
        public string UserId { get; set; }
    }
}
