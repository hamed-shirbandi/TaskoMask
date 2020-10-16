using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public string BoardId { get; set; }

    }
}
