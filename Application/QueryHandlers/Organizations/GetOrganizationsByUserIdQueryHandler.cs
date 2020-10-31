using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.QueryHandlers.Organizations
{
    public class GetOrganizationsByUserIdQueryHandler : IRequestHandler<GetOrganizationsByUserIdQuery, IEnumerable<OrganizationOutput>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        public GetOrganizationsByUserIdQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<OrganizationOutput>> Handle(GetOrganizationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByUserIdAsync(request.UserId);
            //TODO Map organizations to output model
            var model = new List<OrganizationOutput>().AsEnumerable();
            return model;
        }
    }
}
