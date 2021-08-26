using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Commands;
using System.Collections.Generic;
using TaskoMask.Application.Base.Services;

namespace TaskoMask.Application.Cards.Services
{
    public interface ICardService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(CardInputDto input);
        Task<Result<CommandResult>> UpdateAsync(CardInputDto input);
        Task<Result<CardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<CardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<CardReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<CardBasicInfoDto>>> GetListByBoardIdAsync(string boardId);
    }
}
