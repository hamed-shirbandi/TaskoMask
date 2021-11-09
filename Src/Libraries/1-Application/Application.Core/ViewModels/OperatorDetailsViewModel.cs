using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Administration.Operators;
using TaskoMask.Application.Core.Dtos.Administration.Roles;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.ViewModels
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
