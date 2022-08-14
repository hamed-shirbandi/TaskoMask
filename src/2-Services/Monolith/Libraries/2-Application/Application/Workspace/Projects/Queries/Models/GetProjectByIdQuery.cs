using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Queries.Models
{
    public class GetProjectByIdQuery : BaseQuery<ProjectOutputDto>
    {
        public GetProjectByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
