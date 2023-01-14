using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId
{
    public class GetTasksByCardIdHandler : BaseQueryHandler, IRequestHandler<GetTasksByCardIdRequest, IEnumerable<GetTaskDto>>
    {
        #region Fields

        private readonly TaskReadDbContext _taskReadDbContext;

        #endregion

        #region Ctors

        public GetTasksByCardIdHandler(TaskReadDbContext taskReadDbContext, IMapper mapper) : base(mapper)
        {
            _taskReadDbContext = taskReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetTaskDto>> Handle(GetTasksByCardIdRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _taskReadDbContext.Tasks.AsQueryable().Where(e => e.CardId == request.CardId).ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<GetTaskDto>>(tasks);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
