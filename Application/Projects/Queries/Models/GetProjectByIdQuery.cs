using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Projects;

namespace TaskoMask.Application.Projects.Queries.Models
{
   
    public class GetProjectByIdQuery : IRequest<ProjectOutput>
    {
        public GetProjectByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
