using TaskoMask.Application.Administration.Roles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Roles;

namespace TaskoMask.Web.Admin.Areas.Administration.Controllers
{

    [Authorize]
    [Area("Administration")]
    public class RolesController : BaseMvcController
    {
        #region Fields

        private readonly IRoleService _roleService;

        #endregion

        #region Ctor

        public RolesController(IRoleService roleService , IMapper mapper) : base(mapper)
        {
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
            var rolesListQueryResult = await _roleService.GetListAsync();
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
        public async Task<IActionResult> Create(RoleInputDto input)
        {
            var cmdResult = await _roleService.CreateAsync(input);
            return View(cmdResult, input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleService.GetDetailsAsync(id);
            return View(role);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoleInputDto input)
        {
            var cmdResult = await _roleService.UpdateAsync(input);
            return View(cmdResult, input);
        }





        #endregion

        #region Private Methods



        #endregion


    }
}
