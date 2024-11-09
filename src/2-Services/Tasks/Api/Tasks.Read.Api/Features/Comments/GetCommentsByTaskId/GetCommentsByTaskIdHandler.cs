using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;

public class GetCommentsByTaskIdHandler : BaseQueryHandler, IRequestHandler<GetCommentsByTaskIdRequest, IEnumerable<GetCommentDto>>
{
    #region Fields

    private readonly TaskReadDbContext _taskReadDbContext;

    #endregion

    #region Ctors

    public GetCommentsByTaskIdHandler(TaskReadDbContext taskReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<IEnumerable<GetCommentDto>> Handle(GetCommentsByTaskIdRequest request, CancellationToken cancellationToken)
    {
        var comments = await _taskReadDbContext.Comments.AsQueryable().Where(e => e.TaskId == request.TaskId).ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<GetCommentDto>>(comments);
    }

    #endregion

    #region Private Methods




    #endregion
}
