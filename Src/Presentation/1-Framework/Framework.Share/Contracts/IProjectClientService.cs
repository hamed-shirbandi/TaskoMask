using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IProjectClientService
    {
        Task<Result<ProjectBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Create(ProjectUpsertDto input);
        Task<Result<CommandResult>> Update(ProjectUpsertDto input);
        Task<Result<CommandResult>> Delete(string id);
    }
}
