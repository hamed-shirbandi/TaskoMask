using CSharpFunctionalExtensions;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Services.Projects.Dto;

namespace TaskoMask.Application.Queries.Models.Projects
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
