using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById
{
    public class GetProjectByIdHandler : BaseQueryHandler, IRequestHandler<GetProjectByIdRequest, GetProjectDto>
    {
        #region Fields

        private readonly OwnerReadDbContext _ownerReadDbContext;

        #endregion

        #region Ctors

        public GetProjectByIdHandler(OwnerReadDbContext ownerReadDbContext, IMapper mapper) : base(mapper)
        {
            _ownerReadDbContext = ownerReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<GetProjectDto> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {
            var project = await _ownerReadDbContext.Projects.Find(e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (project == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Project);

            return _mapper.Map<GetProjectDto>(project);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
