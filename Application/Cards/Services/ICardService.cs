using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Cards.Services
{
    public interface ICardService : IBaseEntityService
    {
        Task<Result<CardDetailViewModel>> GetDetailAsync(string id);

    }
}
