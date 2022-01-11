using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IMemberClientService
    {
        Task<Result<MemberDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Add(string email);
        Task<Result<CommandResult>> Delete(string id);
    }
}
