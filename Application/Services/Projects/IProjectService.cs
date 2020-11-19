using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Application.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Projects
{
    public interface IProjectService
    {
        Task<Result<CommandResult>> CreateAsync(ProjectInput input);
        Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId);
        Task<long> CountAsync();

    }
}
