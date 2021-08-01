using TaskoMask.Application.Core.Helpers;
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

        Task<Result<CommandResult>> CreateAsync(CardInputDto input);
        Task<Result<CommandResult>> UpdateAsync(CardInputDto input);

        #endregion

        #region Query Services

        Task<CardOutputDto> GetByIdAsync(string id);
        Task<CardInputDto> GetByIdToUpdateAsync(string id);
        Task<CardDetailViewModel> GetListByBoardIdAsync(string boardId);

        #endregion

    }
}
