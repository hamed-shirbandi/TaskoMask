using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
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
