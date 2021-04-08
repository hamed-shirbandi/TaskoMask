using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Boards;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Application.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Boards
{
    public class BoardService : BaseApplicationService, IBoardService
    {
       

        public BoardService(IMediator mediator, IMapper mapper):base(mediator,mapper)
        { }



        public async Task<Result<CommandResult>> CreateAsync(BoardInput input)
        {
            var project = _mapper.Map<CreateBoardCommand>(input);

            return await _mediator.Send(project);
        }


        public async Task<Result<CommandResult>> UpdateAsync(BoardInput input)
        {
            var updateCommand = _mapper.Map<UpdateBoardCommand>(input);
            return await _mediator.Send(updateCommand);
        }

        public async Task<BoardOutput> GetByIdAsync(string id)
        {
            var query = new GetBoardByIdQuery(id);
            return await _mediator.Send(query);
        }


        public async Task<BoardInput> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<BoardInput>(organization);
        }



        public async Task<BoardListViewModel> GetListByProjectIdAsync(string projectId)
        {
            var boardsQuery = new GetBoardsByProjectIdQuery(projectId: projectId);
            var boards= await _mediator.Send(boardsQuery);

            var projectQuery = new GetProjectByIdQuery(id: projectId);
            var project = await _mediator.Send(projectQuery);

            return new BoardListViewModel
            {
                Project = project,
                Boards = boards,
            };
        }


        public async Task<long> CountAsync()
        {
            var query = new GetBoardsCountQuery();
            return  await _mediator.Send(query);
        }

       
    }
}
