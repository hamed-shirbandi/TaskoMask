using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class MemberWebService : IMemberWebService
    {
        private readonly IHttpClientServices _httpClientServices;

        public MemberWebService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

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
