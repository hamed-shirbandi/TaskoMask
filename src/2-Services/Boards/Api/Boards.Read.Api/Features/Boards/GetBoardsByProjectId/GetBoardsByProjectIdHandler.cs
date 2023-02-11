using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId
{
    public class GetBoardsByProjectIdHandler : BaseQueryHandler, IRequestHandler<GetBoardsByProjectIdRequest, IEnumerable<GetBoardDto>>
    {
        #region Fields

        private readonly BoardReadDbContext _boardReadDbContext;

        #endregion

        #region Ctors

        public GetBoardsByProjectIdHandler(BoardReadDbContext boardReadDbContext, IMapper mapper) : base(mapper)
        {
            _boardReadDbContext = boardReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetBoardDto>> Handle(GetBoardsByProjectIdRequest request, CancellationToken cancellationToken)
        {
            var boards = await _boardReadDbContext.Boards.AsQueryable().Where(e => e.ProjectId == request.ProjectId).ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<GetBoardDto>>(boards);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
