using AutoMapper;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardByIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetBoardById
{
    public class GetBoardByIdHandler : BaseQueryHandler, IRequestHandler<GetBoardByIdRequest, BoardDetailsViewModel>
    {
        #region Fields

        private readonly GetBoardByIdGrpcServiceClient _getBoardByIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetBoardByIdHandler(IMapper mapper, GetBoardByIdGrpcServiceClient getBoardByIdGrpcServiceClient) : base(mapper)
        {
            _getBoardByIdGrpcServiceClient = getBoardByIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<BoardDetailsViewModel> Handle(GetBoardByIdRequest request, CancellationToken cancellationToken)
        {

            return new BoardDetailsViewModel
            {
                Board = GetBoardAndMapToDto(request.Id),
                Cards = await GetCardsAndMapToDto(request.Id),
            };

        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private GetBoardDto GetBoardAndMapToDto(string boardId)
        {
            //TODO get the board from board read service by an RPC call
            return new GetBoardDto();
        }




        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<CardDetailsViewModel>> GetCardsAndMapToDto(string boardId)
        {
            //TODO get the cards from board read service by an RPC call
            return new List<CardDetailsViewModel>();
        }




        #endregion

    }
}
