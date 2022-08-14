using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;

namespace TaskoMask.Services.Monolith.Presentation.UI.AdminPanle.Area.Admin.Models
{
    public class DashboardIndexViewModel
    {
        public long OwnersCount { get; set; }
        public long OrganizationsCount { get; set; }
        public long ProjectsCount { get; set; }
        public long BoardsCount { get; set; }
        public long TasksCount { get; set; }
        public long CardsCount { get; set; }
    }
}
