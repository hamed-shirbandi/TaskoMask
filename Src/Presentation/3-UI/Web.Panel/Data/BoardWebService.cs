using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Data
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
