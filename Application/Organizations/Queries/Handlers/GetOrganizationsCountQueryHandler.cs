using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Organizations.Queries.Handlers
{
    public class GetOrganizationsCountQueryHandler : IRequestHandler<GetOrganizationsCountQuery, long>
    {
        private readonly IOrganizationRepository _organizationRepository;
        public GetOrganizationsCountQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<long> Handle(GetOrganizationsCountQuery request, CancellationToken cancellationToken)
        {
            return await _organizationRepository.CountAsync();
        }
    }
}
