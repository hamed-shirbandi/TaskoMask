using System.Collections.Generic;
using TaskoMask.Application.Share.ViewModels;

namespace TaskoMask.Presentation.UI.AdminPanle.Area.Admin.Models
{
    public class DashboardIndexViewModel
    {
        public long MembersCount { get; set; }
        public long OrganizationsCount { get; set; }
        public long ProjectsCount { get; set; }
        public long BoardsCount { get; set; }
        public long TasksCount { get; set; }
        public long CardsCount { get; set; }
    }
}
