using System.Text.Json;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.UI.UserPanel.Helpers;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class AccountWebService : IAccountWebService
    {
        private readonly HttpClient _httpClient;

        public AccountWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<string>> Login(UserLoginDto input)
        {
            var uri = new ClientUriBuilder(new Uri(_httpClient.BaseAddress, $"/account/login")).Uri;
            var httpResponse = await _httpClient.PostAsJsonAsync<UserLoginDto>(uri, input);
            if (httpResponse.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<Result<string>>(httpResponse.Content.ReadAsStream());
            return Result.Failure<string>(message: $"Request failed. statusCode= {httpResponse.StatusCode}");

        }



        public Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            throw new NotImplementedException();
        }
    }
}
