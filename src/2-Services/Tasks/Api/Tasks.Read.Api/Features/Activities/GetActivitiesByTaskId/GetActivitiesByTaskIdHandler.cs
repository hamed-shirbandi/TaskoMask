using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId;

public class GetActivitiesByTaskIdHandler : BaseQueryHandler, IRequestHandler<GetActivitiesByTaskIdRequest, IEnumerable<GetActivityDto>>
{
    #region Fields

    private readonly TaskReadDbContext _taskReadDbContext;

    #endregion

    #region Ctors

    public GetActivitiesByTaskIdHandler(TaskReadDbContext taskReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<IEnumerable<GetActivityDto>> Handle(GetActivitiesByTaskIdRequest request, CancellationToken cancellationToken)
    {
        var activities = await _taskReadDbContext.Activities.AsQueryable().Where(e => e.TaskId == request.TaskId).ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<GetActivityDto>>(activities);
    }

    #endregion

    #region Private Methods




    #endregion
}
