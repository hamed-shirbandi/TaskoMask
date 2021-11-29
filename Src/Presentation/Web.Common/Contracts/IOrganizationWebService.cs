using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface IOrganizationWebService
    {
        Task<Result<CommandResult>> Create(OrganizationUpsertDto input);
        Task<Result<OrganizationDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(OrganizationUpsertDto input);
    }
}
