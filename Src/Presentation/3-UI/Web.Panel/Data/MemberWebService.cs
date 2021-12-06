using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class MemberWebService : IMemberWebService
    {
        public Task<Result<CommandResult>> Add(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<MemberBasicInfoDto>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update()
        {
            throw new NotImplementedException();
        }
    }
}
