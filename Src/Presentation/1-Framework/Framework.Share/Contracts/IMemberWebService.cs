using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Presentation.Framework.Share.Contracts
{
    public interface IMemberWebService
    {
        Task<Result<CommandResult>> Add(string email);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<MemberBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Update();
    }
}
