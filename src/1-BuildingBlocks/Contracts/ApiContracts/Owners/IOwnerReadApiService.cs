using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Owners
{
    public interface IOwnerReadApiService
    {
        Task<Result<OwnerBasicInfoDto>> Get();
    }
}
