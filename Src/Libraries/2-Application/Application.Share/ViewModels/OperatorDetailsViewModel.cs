using TaskoMask.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Share.ViewModels
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
