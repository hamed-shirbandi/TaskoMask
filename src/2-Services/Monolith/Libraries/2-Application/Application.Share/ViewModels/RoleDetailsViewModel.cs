using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Operators;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Roles;
using TaskoMask.Services.Monolith.Application.Share.Helpers;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
{
    public class RoleDetailsViewModel
    {
        public RoleDetailsViewModel()
        {
            Operators = new List<OperatorBasicInfoDto>();
            Permissions = new Dictionary<string, IEnumerable<SelectListItem>>();
        }

        public RoleUpsertDto Role { get; set; }
        public IEnumerable<OperatorBasicInfoDto> Operators { get; set; }
        public Dictionary<string, IEnumerable<SelectListItem>> Permissions { get; set; }

    }
}
