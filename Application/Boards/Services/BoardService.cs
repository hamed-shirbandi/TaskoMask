using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Dtos.Projects;
using System.Collections.Generic;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Core.Notifications;
using System.Linq;

namespace TaskoMask.Application.Boards.Services
{
    public class BoardService : BaseEntityService<Board>, IBoardService
    {
        #region Fields


        #endregion

        #region Ctor

        public BoardService(IMediator mediator, IMapper mapper, INotificationHandler<DomainNotification> notifications) : base(mediator, mapper, notifications)
        { }

        #endregion

        #region Command Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(BoardInputDto input)
        {
            var createCommand = _mapper.Map<CreateBoardCommand>(input);

            return await SendCommandAsync(createCommand);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(BoardInputDto input)
        {
            var updateCommand = _mapper.Map<UpdateBoardCommand>(input);
            return await SendCommandAsync(updateCommand);
        }


        #endregion

        #region Query Services



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardOutput>> GetByIdAsync(string id)
        {
            var query = new GetBoardByIdQuery(id);
            return await SendQueryAsync<GetBoardByIdQuery, BoardOutput>(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardInputDto>> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<BoardInputDto>(organization);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardListViewModel>> GetListByProjectIdAsync(string projectId)
        {
            var boardsQuery = new GetBoardsByProjectIdQuery(projectId: projectId);
            var boards = await SendQueryAsync<GetBoardsByProjectIdQuery, IEnumerable<BoardOutput>>(boardsQuery);

            var projectQuery = new GetProjectByIdQuery(id: projectId);
            var project = await SendQueryAsync<GetProjectByIdQuery, ProjectOutputDto>(projectQuery);

            return new BoardListViewModel
            {
                Project = project.Value,
                Boards = boards.Value,
            };
        }





        #endregion

    }
}
