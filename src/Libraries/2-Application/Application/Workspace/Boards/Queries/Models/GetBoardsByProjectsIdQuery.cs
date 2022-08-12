using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Queries;


namespace TaskoMask.Application.Workspace.Boards.Queries.Models
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
