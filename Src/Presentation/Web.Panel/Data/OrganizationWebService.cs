using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
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
