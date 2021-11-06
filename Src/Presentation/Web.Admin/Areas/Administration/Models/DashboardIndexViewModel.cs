using System.Collections.Generic;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Admin.Area.Admin.Models
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
