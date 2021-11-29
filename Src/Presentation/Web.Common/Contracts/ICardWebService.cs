using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Common.Contracts
{
    public interface ICardWebService
    {
        Task<Result<CommandResult>> Create(CardUpsertDto input);
        Task<Result<CardDetailsViewModel>> Get(string id);
        Task<Result<CommandResult>> Update(CardUpsertDto input);
    }
}
