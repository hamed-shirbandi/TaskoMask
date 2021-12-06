using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class TaskWebService : ITaskWebService
    {
        public Task<Result<CommandResult>> Create(TaskUpsertDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> SetCardId(string taskId, string cardId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update(TaskUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}
