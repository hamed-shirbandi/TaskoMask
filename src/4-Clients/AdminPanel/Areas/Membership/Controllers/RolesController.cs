using TaskoMask.Services.Monolith.Application.Membership.Roles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Membership.Roles;
using TaskoMask.BuildingBlocks.Web.MVC.Filters;
using TaskoMask.BuildingBlocks.Web.MVC.Extensions;
using TaskoMask.BuildingBlocks.Web.MVC.Enums;
using TaskoMask.BuildingBlocks.Web.MVC.Helpers;

namespace TaskoMask.Clients.AdminPanle.Areas.Membership.Controllers
{

    [Authorize]
    [Area("Membership")]
    public class RolesController : BaseMvcController
    {
        #region Fields

        private readonly IRoleService _roleService;

        #endregion

        #region Ctor

        public RolesController(IRoleService roleService, IMapper mapper) : base(mapper)
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
        public IActionResult Create()
        {
            return View();
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleUpsertDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _roleService.CreateAsync(input);
            var redirectUrl = $"/membership/roles/update/EntityId";
            return AjaxResult(cmdResult,redirectUrl: redirectUrl);
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
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoleUpsertDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _roleService.UpdateAsync(input);
            return AjaxResult(cmdResult);
        }





        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdatePermissions(string id, string[] PermissionsId)
        {
            var cmdResult = await _roleService.UpdatePermissionsAsync(id, PermissionsId);
            return AjaxResult(cmdResult);
        }



        #endregion

        #region Private Methods



        #endregion


    }
}
