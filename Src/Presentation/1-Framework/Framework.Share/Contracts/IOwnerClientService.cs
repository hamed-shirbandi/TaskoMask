using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IOwnerClientService
    {
        Task<Result<OwnerDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Add(string email);
        Task<Result<CommandResult>> Delete(string id);
    }
}
