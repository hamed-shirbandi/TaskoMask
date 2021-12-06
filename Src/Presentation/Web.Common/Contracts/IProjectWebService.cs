using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface IProjectWebService
    {
        Task<Result<CommandResult>> Create(ProjectUpsertDto input);
        Task<Result<ProjectDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(ProjectUpsertDto input);
    }
}
