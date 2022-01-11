using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Workspace.Projects.Queries.Models
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
