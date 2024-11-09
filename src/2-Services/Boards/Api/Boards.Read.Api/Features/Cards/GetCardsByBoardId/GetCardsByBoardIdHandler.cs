using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;

public class GetCardsByBoardIdHandler : BaseQueryHandler, IRequestHandler<GetCardsByBoardIdRequest, IEnumerable<GetCardDto>>
{
    #region Fields

    private readonly BoardReadDbContext _boardReadDbContext;

    #endregion

    #region Ctors

    public GetCardsByBoardIdHandler(BoardReadDbContext boardReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _boardReadDbContext = boardReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<IEnumerable<GetCardDto>> Handle(GetCardsByBoardIdRequest request, CancellationToken cancellationToken)
    {
        var cards = await _boardReadDbContext.Cards.AsQueryable().Where(o => o.BoardId == request.BoardId).ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<GetCardDto>>(cards);
    }

    #endregion

    #region Private Methods




    #endregion
}
