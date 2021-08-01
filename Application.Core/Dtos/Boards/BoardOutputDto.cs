

using System;

namespace TaskoMask.Application.Core.Dtos.Boards
{
    public class BoardOutputDto : BoardBasicInfoDto
    {
        public BoardReportDto Reports { get; set; }
        
    }
}
