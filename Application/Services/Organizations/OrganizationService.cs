﻿using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Organizations;
using TaskoMask.Application.Queries.Models.Organizations;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Data;

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


        public async Task<IEnumerable<OrganizationOutput>> GetListByUserIdAsync(string userId)
        {
            var query = new GetOrganizationsByUserIdQuery(userId: userId);
            return await _mediator.Send(query);
        }


        public async Task<long> CountAsync()
        {
            var query = new GetOrganizationsCountQuery();
            return  await _mediator.Send(query);
        }

       
    }
}
