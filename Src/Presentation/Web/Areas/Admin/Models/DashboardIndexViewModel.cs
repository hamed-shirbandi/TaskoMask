using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Area.Admin.Models
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<OrganizationDetailsViewModel> OrganizationsDetailsList { get; set; }

    }
}
