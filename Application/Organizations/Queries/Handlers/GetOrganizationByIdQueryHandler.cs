using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Organizations.Queries.Handlers
{
    public class GetOrganizationByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationOutput>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public GetOrganizationByIdQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<OrganizationOutput> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<OrganizationOutput>(organization);
        }
    }
}
