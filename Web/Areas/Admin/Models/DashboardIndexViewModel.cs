using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.Core.Dtos.Users;

namespace TaskoMask.web.Area.Admin.Models
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<OrganizationOutput> Organizations { get; set; }
        public UserOutput User { get; set; }
    }
}
