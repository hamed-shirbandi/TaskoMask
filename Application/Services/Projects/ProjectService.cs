using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IMediator _mediator;

        public ProjectService(IMediator mediator)
        {
            _mediator = mediator;
        }



        public async Task<Result> CreateAsync(ProjectInput input)
        {
            //TODO replace with AutoMapper
            var project = new CreateProjectCommand(input.Name, input.Description, input.OrganizationId);
            return await _mediator.Send(project);
        }


        public async Task<IEnumerable<ProjectOutput>> GetListByOrganizationIdAsync(string organizationId)
        {
            var query = new GetProjectsByOrganizationIdQuery(organizationId: organizationId);
            return await _mediator.Send(query);
        }


        public async Task<long> CountAsync()
        {
            var query = new GetProjectsCountQuery();
            return  await _mediator.Send(query);
        }

       
    }
}
