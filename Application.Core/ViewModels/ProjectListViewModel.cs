using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class ProjectListViewModel
    {
        public OrganizationOutput Organization { get; set; }
        public IEnumerable<ProjectOutput> Projects { get; set; }
    }
}
