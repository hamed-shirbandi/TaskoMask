using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Boards.Services;
using TaskoMask.Application.Core.Dtos.Boards;
using Microsoft.AspNetCore.Authorization;

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

        public BoardsController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        #endregion

        #region Public Methods





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

            var result = await _boardService.CreateAsync(input);
            ValidateResult(result);

            return View(input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var board = await _boardService.GetByIdAsync(id);
            return View(board);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(BoardInputDto input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var result = await _boardService.UpdateAsync(input);

            ValidateResult(result);

            return View(input);
        }




        #endregion

    }
}
