using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Area.Admin.Models
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<OrganizationDetailViewModel> Organizations { get; set; }

    }
}
