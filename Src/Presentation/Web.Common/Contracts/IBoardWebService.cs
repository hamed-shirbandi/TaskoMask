using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface IBoardWebService
    {
        Task<Result<CommandResult>> Create(BoardUpsertDto input);
        Task<Result<BoardDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(BoardUpsertDto input);
    }
}
