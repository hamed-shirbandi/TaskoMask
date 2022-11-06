using AutoMapper;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetProjectById
{
    public class GetProjectByIdHandler : BaseQueryHandler, IRequestHandler<GetProjectByIdRequest, ProjectDetailsViewModel>
    {
        #region Fields


        #endregion

        #region Ctors

        public GetProjectByIdHandler(IMapper mapper) : base(mapper)
        {
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Private Methods




        #endregion

    }
}
