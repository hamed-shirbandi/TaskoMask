using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetOrganizationsByUserIdQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizationOutput>> Handle(GetOrganizationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<OrganizationOutput>>(organizations);
        }
    }
}
