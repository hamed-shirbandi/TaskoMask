using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Team.Projects;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface IProjectWebService
    {
        Task<Result<CommandResult>> Create(ProjectUpsertDto input);
        Task<Result<ProjectDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(ProjectUpsertDto input);
    }
}
