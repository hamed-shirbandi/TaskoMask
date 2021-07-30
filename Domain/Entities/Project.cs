using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.Project), ResourceType = typeof(DomainMetadata))]
    public class Project : BaseEntity
    {
        public Project(string name, string description, string organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }


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
