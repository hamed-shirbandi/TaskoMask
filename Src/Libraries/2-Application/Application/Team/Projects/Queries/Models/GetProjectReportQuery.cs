using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Team.Projects.Queries.Models
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
