using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.Clients.AdminPanle.Area.Admin.Models
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
