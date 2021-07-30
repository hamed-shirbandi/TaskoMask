using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Task), ResourceType = typeof(DomainMetadata))]
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CardId { get; set; }
    }
}
