using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }
    }
}
