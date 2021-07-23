using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Cards.Services
{
    public interface ICardService : IBaseEntityService
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
