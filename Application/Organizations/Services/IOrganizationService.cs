using TaskoMask.Application.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Application.Organizations.Services
{
    public interface IOrganizationService : IBaseEntityService
    {
        Task<Result<OrganizationDetailViewModel>> GetDetailAsync(string id);
    }
}
