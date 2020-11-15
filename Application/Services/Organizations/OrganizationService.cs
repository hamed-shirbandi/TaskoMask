using AutoMapper;
using CSharpFunctionalExtensions;
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
        private readonly IMapper _mapper;

        public OrganizationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        public async Task<Result> CreateAsync(OrganizationInput input)
        {
            var organization = _mapper.Map<CreateOrganizationCommand>(input);
            return await _mediator.Send(organization);
        }


        public async Task<Result> UpdateAsync(OrganizationInput input)
        {
            //var organization = GetByIdAsync(input.Id);

            //var organization = _mapper.Map<UpdateOrganizationCommand>(input);
            //return await _mediator.Send(organization);

            return Result.Success();
        }

        public async Task<OrganizationOutput> GetByIdAsync(string id)
        {
            var query = new GetOrganizationByIdQuery(id);
            return await _mediator.Send(query);
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
