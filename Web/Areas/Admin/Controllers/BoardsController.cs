using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Boards.Services;
using TaskoMask.Application.Core.Dtos.Boards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Area.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class BoardsController : BaseController
    {
        #region Fields

        private readonly IBoardService _boardService;

        #endregion

        #region Ctors

        public BoardsController(IBoardService boardService, IMapper mapper) : base(mapper)
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
            return View(boardDetailQueryResult);
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

            var cmdResult = await _boardService.CreateAsync(input);
            return View(cmdResult, input);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var boardQueryResult = await _boardService.GetByIdAsync(id);
            return View<BoardBasicInfoDto, BoardInputDto>(boardQueryResult);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(BoardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var cmdResult = await _boardService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

    }
}
