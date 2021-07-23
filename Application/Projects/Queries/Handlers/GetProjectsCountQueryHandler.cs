using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Projects.Queries.Handlers
{
    public class GetProjectsCountQueryHandler : IRequestHandler<GetProjectsCountQuery, long>
    {
        private readonly IProjectRepository _projectRepository;
        public GetProjectsCountQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<long> Handle(GetProjectsCountQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.CountAsync();
        }
    }
}
