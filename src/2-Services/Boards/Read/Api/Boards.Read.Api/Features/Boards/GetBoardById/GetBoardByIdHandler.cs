using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById
{
    public class GetBoardByIdHandler : BaseQueryHandler, IRequestHandler<GetBoardByIdRequest, GetBoardDto>
    {
        #region Fields

        private readonly BoardReadDbContext _boardReadDbContext;

        #endregion

        #region Ctors

        public GetBoardByIdHandler(BoardReadDbContext boardReadDbContext, IMapper mapper) : base(mapper)
        {
            _boardReadDbContext = boardReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<GetBoardDto> Handle(GetBoardByIdRequest request, CancellationToken cancellationToken)
        {
            var board = await _boardReadDbContext.Boards.Find(e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (board == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Board);

            return _mapper.Map<GetBoardDto>(board);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
