using TaskoMask.BuildingBlocks.Web.Services;
using TaskoMask.Clients.UserPanel.Helpers;

namespace TaskoMask.Clients.UserPanel.Services.API;

public abstract class BaseApiService
{
    protected readonly IHttpClientService _httpClientService;

    public BaseApiService(IHttpClientService httpClientService, string clientName = MagicKey.PROTECTED_APIGATEWAY_CLIENT)
    {
        _httpClientService = httpClientService.WithNamedClient(clientName);
    }
}
