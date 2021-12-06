using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Share.Dtos.Workspace.Cards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface ICardWebService
    {
        Task<Result<CommandResult>> Create(CardUpsertDto input);
        Task<Result<CardDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(CardUpsertDto input);
    }
}
