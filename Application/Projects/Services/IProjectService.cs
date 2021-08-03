using TaskoMask.Application.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Projects.Services
{
    public interface IProjectService : IBaseEntityService
    {
        Task<Result<ProjectDetailViewModel>> GetDetailAsync(string id);

    }
}
