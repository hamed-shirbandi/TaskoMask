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
using TaskoMask.Application.Core.Queries;using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Organizations.Queries.Handlers
{
    public class OrganizationsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOrganizationByIdQuery, OrganizationBasicInfoDto>,
        IRequestHandler<GetOrganizationReportQuery, OrganizationReportDto>,
        IRequestHandler<GetOrganizationsByUserIdQuery, IEnumerable<OrganizationBasicInfoDto>>
    {
        private readonly IOrganizationRepository _organizationRepository;
        public OrganizationsQueryHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationBasicInfoDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Organization);

            return _mapper.Map<OrganizationBasicInfoDto>(organization);
        }


        public async Task<IEnumerable<OrganizationBasicInfoDto>> Handle(GetOrganizationsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByUserIdAsync(request.UserId);
            return _mapper.Map<IEnumerable<OrganizationBasicInfoDto>>(organizations);
        }



        public Task<OrganizationReportDto> Handle(GetOrganizationReportQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
