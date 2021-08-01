using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Application.Core.Dtos.Users
{
   public class UserOutputDto : UserBasicInfoDto
    {
        public UserReportDto Reports { get; set; }
    }
}
