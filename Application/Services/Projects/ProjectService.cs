using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Queries.Models.Organizations;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Application.ViewMoldes;
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


        public async Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId)
        {
            var projectsQuery = new GetProjectsByOrganizationIdQuery(organizationId: organizationId);
            var projects= await _mediator.Send(projectsQuery);

            var organizationQuery = new GetOrganizationByIdQuery(id: organizationId);
            var organization = await _mediator.Send(organizationQuery);

            return new ProjectListViewModel
            {
                Organization= organization,
                Projects = projects,
            };
        }


        public async Task<long> CountAsync()
        {
            var query = new GetProjectsCountQuery();
            return  await _mediator.Send(query);
        }

       
    }
}
