using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Contracts.ViewModels;

public class PanelDashboardViewModel
{
    public PanelDashboardViewModel()
    {
        OrganizationsDetailsList = new List<OrganizationDetailsViewModel>();
    }

    public IEnumerable<OrganizationDetailsViewModel> OrganizationsDetailsList { get; set; }
}
