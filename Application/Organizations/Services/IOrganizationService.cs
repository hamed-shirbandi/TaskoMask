using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Organizations
{
    public interface IOrganizationService
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(OrganizationInput input);
        Task<Result<CommandResult>> UpdateAsync(OrganizationInput input);


        #endregion

        #region Query Services

        Task<OrganizationOutput> GetByIdAsync(string id);
        Task<OrganizationInput> GetByIdToUpdateAsync(string id);
        Task<IEnumerable<OrganizationOutput>> GetListByUserIdAsync(string userId);
        Task<long> CountAsync();


        #endregion
       
    }
}
