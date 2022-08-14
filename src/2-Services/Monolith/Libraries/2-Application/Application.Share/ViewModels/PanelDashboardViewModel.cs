using System.Collections.Generic;

namespace TaskoMask.Services.Monolith.Application.Share.ViewModels
{
    public class PanelDashboardViewModel
    {
        public PanelDashboardViewModel()
        {
            OrganizationsDetailsList = new List<OrganizationDetailsViewModel>();
        }

        public IEnumerable<OrganizationDetailsViewModel> OrganizationsDetailsList { get; set; }

    }
}
