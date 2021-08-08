using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Domain.Core.Queries;

namespace TaskoMask.Application.Queries.Models.Boards
{
   
    public class GetBoardByIdQuery : BaseQuery<BoardBasicInfoDto>
    {
        public GetBoardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
