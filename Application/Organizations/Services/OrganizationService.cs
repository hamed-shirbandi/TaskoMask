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
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Organizations.Services
{
    public class OrganizationService : BaseEntityService<Organization>, IOrganizationService
    {
        public OrganizationService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }

        public async Task<Result<CommandResult>> CreateAsync(OrganizationInput input)
        {
            var createCommand = _mapper.Map<CreateOrganizationCommand>(input);
            return await SendCommandAsync(createCommand);
        }


        public async Task<Result<CommandResult>> UpdateAsync(OrganizationInput input)
        {
            var updateCommand = _mapper.Map<UpdateOrganizationCommand>(input);
            return await SendCommandAsync(updateCommand);
        }

        public async Task<OrganizationOutput> GetByIdAsync(string id)
        {
            var query = new GetOrganizationByIdQuery(id);
            return await SendQueryAsync<GetOrganizationByIdQuery, OrganizationOutput>(query);
        }


        public async Task<OrganizationInput> GetByIdToUpdateAsync(string id)
        {
            var organization=await GetByIdAsync(id);
            return _mapper.Map<OrganizationInput>(organization);
        }


        public async Task<IEnumerable<OrganizationOutput>> GetListByUserIdAsync(string userId)
        {
            var query = new GetOrganizationsByUserIdQuery(userId: userId);
            return await SendQueryAsync<GetOrganizationsByUserIdQuery, IEnumerable<OrganizationOutput>>(query);
        }


        public async Task<long> CountAsync()
        {
            var query = new GetOrganizationsCountQuery();
            return  await SendQueryAsync<GetOrganizationsCountQuery, long>(query);
        }

       
    }
}
