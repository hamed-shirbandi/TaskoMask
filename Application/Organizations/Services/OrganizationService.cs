using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Organizations.Commands.Models;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Data;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Organizations.Services
{
    public class OrganizationService : BaseApplicationService, IOrganizationService
    {
        public OrganizationService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        public async Task<Result<CommandResult>> CreateAsync(OrganizationInput input)
        {
            var createCommand = _mapper.Map<CreateOrganizationCommand>(input);
            return await _mediator.Send(createCommand);
        }


        public async Task<Result<CommandResult>> UpdateAsync(OrganizationInput input)
        {
            var updateCommand = _mapper.Map<UpdateOrganizationCommand>(input);
            return await _mediator.Send(updateCommand);
        }

        public async Task<OrganizationOutput> GetByIdAsync(string id)
        {
            var query = new GetOrganizationByIdQuery(id);
            return await _mediator.Send(query);
        }


        public async Task<OrganizationInput> GetByIdToUpdateAsync(string id)
        {
            var organization=await GetByIdAsync(id);
            return _mapper.Map<OrganizationInput>(organization);
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
