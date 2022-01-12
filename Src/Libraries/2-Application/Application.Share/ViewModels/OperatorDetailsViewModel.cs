using System.Collections.Generic;
using TaskoMask.Application.Share.Dtos.Administration.Operators;
using TaskoMask.Application.Share.Dtos.Administration.Roles;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Share.ViewModels
{
    public class OperatorDetailsViewModel
    {
        public OperatorDetailsViewModel()
        {
            Roles = new List<SelectListItem>();
        }

        public OperatorUpsertDto Operator { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
