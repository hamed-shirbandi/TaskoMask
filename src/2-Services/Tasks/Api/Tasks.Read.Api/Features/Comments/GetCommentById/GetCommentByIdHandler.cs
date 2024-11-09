using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentById;

public class GetCommentByIdHandler : BaseQueryHandler, IRequestHandler<GetCommentByIdRequest, GetCommentDto>
{
    #region Fields

    private readonly TaskReadDbContext _taskReadDbContext;

    #endregion

    #region Ctors

    public GetCommentByIdHandler(TaskReadDbContext taskReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<GetCommentDto> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
    {
        var comment = await _taskReadDbContext.Comments.Find(e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (comment == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Comment);

        return _mapper.Map<GetCommentDto>(comment);
    }

    #endregion

    #region Private Methods




    #endregion
}
