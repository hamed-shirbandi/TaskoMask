using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Application.Commands.Organizations;

namespace TaskoMask.Application.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IMediator _mediator;
        public OrganizationService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<Result> CreateAsync(OrganizationInput input)
        {
            //TODO replace with AutoMapper
            var organization = new CreateOrganizationCommand(input.Name, input.Description, input.UserId);
            return await _mediator.Send(organization);
        }
    }
}
