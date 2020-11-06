using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Organizations
{
    public class GetOrganizationsByIdQueryHandler : IRequestHandler<GetOrganizationByIdQuery, OrganizationOutput>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public GetOrganizationsByIdQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<OrganizationOutput> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<OrganizationOutput>(organizations);
        }
    }
}
