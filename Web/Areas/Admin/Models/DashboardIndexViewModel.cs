using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Organizations.Dto;
using TaskoMask.Application.Services.Users.Dto;

namespace TaskoMask.web.Area.Admin.Models
{
    public class DashboardIndexViewModel
    {
        public IEnumerable<OrganizationOutput> Organizations { get; set; }
        public UserOutput User { get; set; }
    }
}
