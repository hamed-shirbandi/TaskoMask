using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
{
    public class OperatorDetailsViewModel
    {
        public OperatorDetailsViewModel()
        {
            Roles = new List<SelectListItem>();
        }

        public OperatorBasicInfoDto Operator { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
