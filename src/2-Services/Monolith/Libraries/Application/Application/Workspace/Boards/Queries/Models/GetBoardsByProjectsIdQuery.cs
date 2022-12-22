using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Application.Queries;


namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models
{
   
    public class GetBoardsByProjectsIdQuery : BaseQuery<IEnumerable<GetBoardDto>>
    {
        public GetBoardsByProjectsIdQuery(string[] projectsId)
        {
            ProjectsId = projectsId;
        }

        public string[] ProjectsId { get; }
    }
}
