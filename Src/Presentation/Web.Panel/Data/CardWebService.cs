using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
{
    public class CardWebService : ICardWebService
    {
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
