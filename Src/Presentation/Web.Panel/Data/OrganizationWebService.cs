using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
{
    public class OrganizationWebService : IOrganizationWebService
    {
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
