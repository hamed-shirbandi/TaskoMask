using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class ProjectWebService : IProjectWebService
    {
        private readonly IHttpClientServices _httpClientServices;

        public ProjectWebService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        public Task<Result<CommandResult>> Create(ProjectUpsertDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProjectDetailsViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update(ProjectUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}
