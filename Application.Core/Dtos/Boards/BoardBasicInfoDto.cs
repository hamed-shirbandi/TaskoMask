using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Application.Core.Dtos.Boards
{
    public class BoardBasicInfoDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; }
    }
}
