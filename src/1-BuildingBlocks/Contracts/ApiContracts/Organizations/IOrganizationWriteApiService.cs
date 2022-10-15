using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Organizations
{
    public interface IOrganizationWriteApiService
    {
        Task<Result<CommandResult>> Add(AddOrganizationDto input);
        Task<Result<CommandResult>> Update(string id, UpdateOrganizationDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}
