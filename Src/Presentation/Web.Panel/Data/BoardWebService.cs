using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Workspace.Boards;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
{
    public class BoardWebService : IBoardWebService
    {
        public Task<Result<CommandResult>> Create(BoardUpsertDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update(BoardUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}
