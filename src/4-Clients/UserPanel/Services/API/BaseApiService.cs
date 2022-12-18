using TaskoMask.BuildingBlocks.Web.Services.Http;
using TaskoMask.Clients.UserPanel.Helpers;

namespace TaskoMask.Clients.UserPanel.Services.API
{
    public abstract class BaseApiService 
    {

        protected readonly IHttpClientService _httpClientService;


        public BaseApiService(IHttpClientService httpClientService,string clientName= MagicKey.Protected_ApiGateway_Client)
        {
            _httpClientService = httpClientService.WithNamedClient(clientName);
        }
    }
}
