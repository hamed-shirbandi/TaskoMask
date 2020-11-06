using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Projects.Dto;

namespace TaskoMask.Application.Services.Projects
{
    public interface IProjectService
    {
        Task<Result> CreateAsync(ProjectInput input);
        Task<IEnumerable<ProjectOutput>> GetListByOrganizationIdAsync(string organizationId);
        Task<long> CountAsync();

    }
}
