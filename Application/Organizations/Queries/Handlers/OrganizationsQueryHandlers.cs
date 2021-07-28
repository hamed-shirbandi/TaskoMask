using AutoMapper;
using TaskoMask.Application.Core.Helpers;
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
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Organizations.Queries.Handlers
{
    public class OrganizationsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOrganizationByIdQuery, OrganizationOutput>,
        IRequestHandler<GetOrganizationsByUserIdQuery, IEnumerable<OrganizationOutput>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationsQueryHandlers(IOrganizationRepository organizationRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationOutput> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<OrganizationOutput>(organization);
        }


        public async Task<IEnumerable<OrganizationOutput>> Handle(GetOrganizationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<OrganizationOutput>>(organizations);
        }

    }
}
