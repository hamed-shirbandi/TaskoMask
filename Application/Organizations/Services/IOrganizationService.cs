using TaskoMask.Application.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Organizations.Services
{
    public interface IOrganizationService : IBaseEntityService
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(OrganizationInputDto input);
        Task<Result<CommandResult>> UpdateAsync(OrganizationInputDto input);


        #endregion

        #region Query Services

        Task<OrganizationOutputDto> GetByIdAsync(string id);
        Task<OrganizationInputDto> GetByIdToUpdateAsync(string id);
        Task<IEnumerable<OrganizationOutputDto>> GetListByUserIdAsync(string userId);
        Task GetList(string userId);


        #endregion

    }
}
