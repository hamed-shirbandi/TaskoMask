using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Cards.Dto;
using TaskoMask.Application.Queries.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Cards
{
    public interface ICardService
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(CardInput input);
        Task<Result<CommandResult>> UpdateAsync(CardInput input);

        #endregion

        #region Query Services

        Task<CardOutput> GetByIdAsync(string id);
        Task<CardInput> GetByIdToUpdateAsync(string id);
        Task<long> CountAsync();
        Task<CardListViewModel> GetListByBoardIdAsync(string boardId);

        #endregion

    }
}
