using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Dtos.TaskManagement.Cards;
using TaskoMask.Application.Core.Commands;
using System.Collections.Generic;
using TaskoMask.Application.Common.Base.Services;

namespace TaskoMask.Application.TaskManagement.Cards.Services
{
    public interface ICardService : IBaseService
    {
        Task<Result<CommandResult>> CreateAsync(CardUpsertDto input);
        Task<Result<CommandResult>> UpdateAsync(CardUpsertDto input);
        Task<Result<CardDetailsViewModel>> GetDetailsAsync(string id);
        Task<Result<CardBasicInfoDto>> GetByIdAsync(string id);
        Task<Result<CardReportDto>> GetReportAsync(string id);
        Task<Result<IEnumerable<CardBasicInfoDto>>> GetListByBoardIdAsync(string boardId);
    }
}
