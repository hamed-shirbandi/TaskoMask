using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Core.ViewMoldes
{
   public class ProjectListViewModel
    {
        public OrganizationOutputDto Organization { get; set; }
        public IEnumerable<ProjectOutputDto> Projects { get; set; }
    }
}
