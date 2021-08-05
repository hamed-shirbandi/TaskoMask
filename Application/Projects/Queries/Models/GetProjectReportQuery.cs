using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Projects.Queries.Models
{
   public class GetProjectReportQuery : BaseQuery<ProjectReportDto>
    {
        public GetProjectReportQuery(string projectId)
        {
            ProjectId = projectId;
        }

        public string ProjectId { get; }
    }
}
