using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
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
