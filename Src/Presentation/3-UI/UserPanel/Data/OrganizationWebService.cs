using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class OrganizationWebService : IOrganizationWebService
    {
        private readonly IHttpClientServices _httpClientServices;

        public OrganizationWebService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        public Task<Result<CommandResult>> Create(OrganizationUpsertDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<OrganizationDetailsViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update(OrganizationUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}
