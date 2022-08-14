using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Services.Monolith.Application.Core.Queries;


namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models
{
   
    public class GetBoardsByProjectsIdQuery : BaseQuery<IEnumerable<BoardBasicInfoDto>>
    {
        public GetBoardsByProjectsIdQuery(string[] projectsId)
        {
            ProjectsId = projectsId;
        }

        public string[] ProjectsId { get; }
    }
}
