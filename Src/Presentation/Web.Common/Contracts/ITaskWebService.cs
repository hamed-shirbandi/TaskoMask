using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Workspace.Tasks;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Web.Common.Contracts
{
    public interface ITaskWebService
    {
        Task<Result<CommandResult>> Create(TaskUpsertDto input);
        Task<Result<CommandResult>> SetCardId(string taskId, string cardId);
        Task<Result<CommandResult>> Update(TaskUpsertDto input);
    }
}
