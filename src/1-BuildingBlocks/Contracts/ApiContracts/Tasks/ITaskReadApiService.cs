using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.Tasks
{
    public interface ITaskReadApiService
    {
        Task<Result<TaskBasicInfoDto>> Get(string id);
        Task<Result<TaskDetailsViewModel>> GetDetails(string id);
    }
}
