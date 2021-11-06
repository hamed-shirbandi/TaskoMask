﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Services.Boards;
using TaskoMask.Application.Services.Boards.Dto;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Domain.Core.Events;
using TaskoMask.web.Models;
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
        public async Task<IActionResult> Index(string projectId)
        {
            var boards = await _boardService.GetListByProjectIdAsync(projectId);
            return View(boards);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Create(string projectId)
        {
            var model = new BoardInput
            {
                ProjectId = projectId,
            };

            return View(model);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(BoardInput input)
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
            var board = await _boardService.GetByIdToUpdateAsync(id);
            return View(board);
        }


        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Update(BoardInput input)
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
