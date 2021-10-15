using TaskoMask.Application.Administration.Operators.Services;
using TaskoMask.Application.Administration.Roles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Dtos.Operators;

namespace TaskoMask.Web.Admin.Areas.Administration.Controllers
{

    [Authorize]
    [Area("Administration")]
    public class OperatorsController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;
        private readonly IRoleService _roleService;

        #endregion

        #region Ctor

        public OperatorsController(IOperatorService operatorService, IRoleService roleService, IMapper mapper) : base(mapper)
        {
            _operatorService = operatorService;
            _roleService = roleService;
        }

        #endregion

        #region Public Methods





        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rolesListQueryResult = await _operatorService.GetListAsync();
            return View(rolesListQueryResult);
        }






        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OperatorInputDto input)
        {
            var cmdResult = await _operatorService.CreateAsync(input);
            return View(cmdResult, input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _operatorService.GetDetailsAsync(id);
            return View(role);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OperatorInputDto input)
        {
            var cmdResult = await _operatorService.UpdateAsync(input);
            return View(cmdResult, input);
        }



        #endregion

        #region Private Methods



        #endregion


    }
}
