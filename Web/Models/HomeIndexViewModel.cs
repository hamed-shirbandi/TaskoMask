using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskoMask.Web.Models
{
    public class HomeIndexViewModel
    {
        public long UsersCount { get; set; }
        public long OrganizationsCount { get; set; }
        public long ProjectsCount { get; set; }
        public long BoardsCount { get; set; }
        public long TasksCount { get; set; }
    }
}
