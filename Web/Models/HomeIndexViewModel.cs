using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskoMask.web.Models
{
    public class HomeIndexViewModel
    {
        public long OrganizationsCount { get; set; }
        public long ProjectsCount { get; set; }
        public long BoardsCount { get; set; }
        public long TasksCount { get; set; }
    }
}
