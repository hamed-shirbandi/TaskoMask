using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Application.ViewMoldes;

namespace TaskoMask.Application.Services.Projects
{
    public interface IProjectService
    {
        Task<Result> CreateAsync(ProjectInput input);
        Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId);
        Task<long> CountAsync();

    }
}
