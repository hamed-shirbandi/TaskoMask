using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;

namespace TaskoMask.BuildingBlocks.Contracts.ApiContracts.OwProjectsners
{
    public interface IProjectWriteApiService
    {
        Task<Result<CommandResult>> Add(AddProjectDto input);
        Task<Result<CommandResult>> Update(string id, UpdateProjectDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}
