using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Application.Commands.Organizations;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMediator _mediator;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IMediator mediator, IOrganizationRepository organizationRepository)
        {
            _mediator = mediator;
            _organizationRepository = organizationRepository;
        }



        public async Task<Result> CreateAsync(OrganizationInput input)
        {
            //TODO replace with AutoMapper
            var organization = new CreateOrganizationCommand(input.Name, input.Description, input.UserId);
            return await _mediator.Send(organization);
        }

        
        public async Task<long> CountAsync()
        {
            return await _organizationRepository.CountAsync();
        }
    }
}
