using TaskoMask.Application.Administration.Operators.Services;
using TaskoMask.Application.Administration.Roles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using TaskoMask.Web.Common.Controllers;
using TaskoMask.Application.Core.Dtos.Operators;
using TaskoMask.Web.Common.Helpers;
using TaskoMask.Application.Core.Dtos.Users;

namespace TaskoMask.Web.Admin.Areas.Administration.Controllers
{

    [Authorize]
    [Area("Administration")]
    public class OperatorsController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;

        #endregion

        #region Ctor

        public OperatorsController(IOperatorService operatorService , IMapper mapper) : base(mapper)
        {
            _operatorService = operatorService;
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




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto input)
        {
            var cmdResult = await _operatorService.ResetPasswordAsync(input.Id,input.NewPassword);
            return View(cmdResult, input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto input)
        {
            var cmdResult = await _operatorService.ChangePasswordAsync(input.Id, input.OldPassword, input.NewPassword);
            return View(cmdResult, input);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<JavaScriptResult> SetIsActive(string id, bool isActive)
        {
            var cmdResult = await _operatorService.SetIsActiveAsync(id, isActive);
            return AjaxResult(cmdResult);

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<JavaScriptResult> UpdateRoles(string id, string[]rolesId)
        {
            var cmdResult = await _operatorService.UpdateRolesAsync(id, rolesId);
            return AjaxResult(cmdResult);
        }








        #endregion

        #region Private Methods



        #endregion


    }
}
