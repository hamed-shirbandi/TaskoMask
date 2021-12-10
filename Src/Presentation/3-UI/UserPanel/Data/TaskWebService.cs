using TaskoMask.Application.Share.Dtos.Workspace.Tasks;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class TaskWebService : ITaskWebService
    {
        private readonly IHttpClientServices _httpClientServices;

        public TaskWebService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

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
