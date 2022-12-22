using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId
{
    public class GetCardsByBoardIdHandler : BaseQueryHandler, IRequestHandler<GetCardsByBoardIdRequest, IEnumerable<CardBasicInfoDto>>
    {
        #region Fields

        private readonly BoardReadDbContext _boardReadDbContext;

        #endregion

        #region Ctors

        public GetCardByIdHandler(BoardReadDbContext boardReadDbContext, IMapper mapper) : base(mapper)
        {
            _boardReadDbContext = boardReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<CardBasicInfoDto>> Handle(GetCardsByBoardIdRequest request, CancellationToken cancellationToken)
        {
            var cards = await _boardReadDbContext.Cards.AsQueryable().Where(o => o.BoardId == request.BoardId).ToListAsync();

            return _mapper.Map<CardBasicInfoDto>(cards);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
