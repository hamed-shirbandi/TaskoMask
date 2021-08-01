using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
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
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;

namespace TaskoMask.Application.Organizations.Queries.Handlers
{
    public class OrganizationsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOrganizationByIdQuery, OrganizationOutputDto>,
        IRequestHandler<GetOrganizationsByUserIdQuery, IEnumerable<OrganizationOutputDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationsQueryHandlers(IOrganizationRepository organizationRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationOutputDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, typeof(Organization));

            return _mapper.Map<OrganizationOutputDto>(organization);
        }


        public async Task<IEnumerable<OrganizationOutputDto>> Handle(GetOrganizationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<OrganizationOutputDto>>(organizations);
        }

    }
}
