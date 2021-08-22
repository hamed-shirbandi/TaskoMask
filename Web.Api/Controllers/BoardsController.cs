using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Boards.Services;
using TaskoMask.Application.Core.Dtos.Boards;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Helpers;
using TaskoMask.Application.Core.ViewModels;

namespace TaskoMask.Web.Api.Controllers
{
    [Authorize]
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
        /// get board detail
        /// </summary>
        [HttpGet]
        [Route("boards/{id}")]
        public async Task<Result<BoardDetailsViewModel>> Get(string id)
        {
            return await _boardService.GetDetailsAsync(id);
        }



        /// <summary>
        /// create new board
        /// </summary>
        [HttpPost]
        [Route("boards")]
        public async Task<Result<CommandResult>> Create(BoardInputDto input)
        {
            return await _boardService.CreateAsync(input);
        }



        /// <summary>
        /// update existing board
        /// </summary>
        [HttpPut]
        [Route("boards")]
        public async Task<Result<CommandResult>> Update(BoardInputDto input)
        {
            return await _boardService.UpdateAsync(input);
        }



        #endregion

    }
}
