using System.Collections.Generic;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Panel.Models
{
    public class DashboardIndexViewModel
    {
        public DashboardIndexViewModel()
        {
            OrganizationsDetailsList = new List<OrganizationDetailsViewModel>();
        }

        public IEnumerable<OrganizationDetailsViewModel> OrganizationsDetailsList { get; set; }

    }
}
