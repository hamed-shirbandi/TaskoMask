using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface IBoardWebService
    {
        Task<Result<CommandResult>> Create(BoardUpsertDto input);
        Task<Result<BoardDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(BoardUpsertDto input);
    }
}
