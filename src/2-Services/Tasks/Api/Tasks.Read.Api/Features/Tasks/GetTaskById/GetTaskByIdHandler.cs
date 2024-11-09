using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;

public class GetTaskByIdHandler : BaseQueryHandler, IRequestHandler<GetTaskByIdRequest, GetTaskDto>
{
    #region Fields

    private readonly TaskReadDbContext _taskReadDbContext;

    #endregion

    #region Ctors

    public GetTaskByIdHandler(TaskReadDbContext taskReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<GetTaskDto> Handle(GetTaskByIdRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskReadDbContext.Tasks.Find(e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (task == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Task);

        return _mapper.Map<GetTaskDto>(task);
    }

    #endregion

    #region Private Methods




    #endregion
}
