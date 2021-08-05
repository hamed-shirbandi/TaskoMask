using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Boards.Services;
using TaskoMask.Application.Core.Dtos.Boards;
using Microsoft.AspNetCore.Authorization;
using TaskoMask.Application.Core.Services;
using AutoMapper;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Queries.Models.Boards;

namespace TaskoMask.web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class BoardsController : BaseController
    {
        #region Fields

        private readonly IBoardService _boardService;

        #endregion

        #region Ctor

        public BoardsController(IBoardService boardService, IBaseApplicationService baseApplicationService, IMapper mapper) : base(baseApplicationService, mapper)
        {
            _boardService = boardService;
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var boardDetailQueryResult = await _boardService.GetDetailAsync(id);
            return ReturnDataToViewAsync(boardDetailQueryResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(string projectId)
        {
            var model = new BoardInputDto
            {
                ProjectId = projectId,
            };
            return View(model);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(BoardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmd = new CreateBoardCommand(projectId: input.ProjectId, name: input.Name, description: input.Description);
            await SendCommandAsync(cmd);

            return View(input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return await SendQueryAndReturnMappedDataToViewAsync<BoardBasicInfoDto, BoardInputDto>(new GetBoardByIdQuery(id));
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(BoardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmd = new UpdateBoardCommand(id: input.Id, name: input.Name, description: input.Description);
            await SendCommandAsync(cmd);

            return View(input);
        }



        #endregion

    }
}
