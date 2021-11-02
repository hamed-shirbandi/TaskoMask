using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Application.Core.Dtos.Roles;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Application.Core.ViewModels
{
    public class OperatorDetailViewModel
    {
        public OperatorDetailViewModel()
        {
            Roles = new List<SelectListItem>();
        }

        public OperatorInputDto Operator { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
