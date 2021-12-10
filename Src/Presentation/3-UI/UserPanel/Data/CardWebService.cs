using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.Contracts;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Data
{
    public class CardWebService : ICardWebService
    {
        private readonly IHttpClientServices _httpClientServices;

        public CardWebService(IHttpClientServices httpClientServices)
        {
            _httpClientServices = httpClientServices;
        }

        public Task<Result<CommandResult>> Create(CardUpsertDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CardDetailsViewModel>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Update(CardUpsertDto input)
        {
            throw new NotImplementedException();
        }
    }
}
