

using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Core.Dtos.Cards
{
    public class CardOutputDto : CardBasicInfoDto
    {
        public TaskReportDto Reports { get; set; }
    }
}
