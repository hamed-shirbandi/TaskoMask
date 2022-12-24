using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById
{
    public class GetCardByIdHandler : BaseQueryHandler, IRequestHandler<GetCardByIdRequest, GetCardDto>
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
        public async Task<GetCardDto> Handle(GetCardByIdRequest request, CancellationToken cancellationToken)
        {
            var card = await _boardReadDbContext.Cards.Find(e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (card == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

            return _mapper.Map<GetCardDto>(card);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
