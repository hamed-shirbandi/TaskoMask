using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Application.Services.Projects.Dto;

namespace TaskoMask.Application.ViewMoldes
{
   public class OrganizationDetailsViewModel
    {
        public OrganizationOutput Organization { get; set; }
        public IEnumerable<ProjectOutput> Projects { get; set; }
    }
}
