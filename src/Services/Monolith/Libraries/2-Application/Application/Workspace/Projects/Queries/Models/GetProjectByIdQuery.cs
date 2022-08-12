﻿using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Projects.Queries.Models
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
