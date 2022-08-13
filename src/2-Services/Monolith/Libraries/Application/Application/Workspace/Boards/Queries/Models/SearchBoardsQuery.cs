﻿using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Boards.Queries.Models
{
    public class SearchBoardsQuery : BaseQuery<PaginatedListReturnType<BoardOutputDto>>
    {
        public SearchBoardsQuery(int page, int recordsPerPage, string term)
        {
            Page = page;
            RecordsPerPage = recordsPerPage;
            Term = term;
        }

        public int Page { get; }
        public int RecordsPerPage { get; }
        public string Term { get; }
    }
}
