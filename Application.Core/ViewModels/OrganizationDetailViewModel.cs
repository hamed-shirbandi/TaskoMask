using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Boards;

namespace TaskoMask.Application.Core.ViewModels
{
   public class OrganizationDetailViewModel
    {
        public OrganizationBasicInfoDto Organization { get; set; }
        public IEnumerable<BoardBasicInfoDto> Projects { get; set; }
    }
}
