using TaskoMask.Services.Monolith.Application.Membership.Operators.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using TaskoMask.BuildingBlocks.Web.MVC.Controllers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Membership.Operators;
using TaskoMask.BuildingBlocks.Web.MVC.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.BuildingBlocks.Web.MVC.Filters;
using TaskoMask.BuildingBlocks.Web.MVC.Enums;
using TaskoMask.BuildingBlocks.Web.MVC.Extensions;
using TaskoMask.BuildingBlocks.Web.ApiContracts;

namespace TaskoMask.Clients.AdminPanel.Areas.Membership.Controllers
{

    [Authorize]
    [Area("Membership")]
    public class OperatorsController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;
        private readonly IUserApiService _userApiService;

        #endregion

        #region Ctor

        public OperatorsController(IOperatorService operatorService, IMapper mapper, IUserApiService userApiService) : base()
        {
            _operatorService = operatorService;
            _userApiService = userApiService;
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
        public async Task<IActionResult> Create(OperatorUpsertDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _operatorService.CreateAsync(input);
            var redirectUrl = $"/membership/operators/update/EntityId";
            return AjaxResult(cmdResult, redirectUrl: redirectUrl);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var @operator = await _operatorService.GetDetailsAsync(id);
            return View(@operator);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OperatorUpsertDto input)
        {
            ModelState.Remove(nameof(OperatorUpsertDto.Password));
            ModelState.Remove(nameof(OperatorUpsertDto.ConfirmPassword));

            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _operatorService.UpdateAsync(input);
            return AjaxResult(cmdResult);
        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _userApiService.ResetPassword(input);
            return AjaxResult(cmdResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto input)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetErrors();
                return ScriptBox.ShowMessage(errors, MessageType.error);
            }

            var cmdResult = await _userApiService.ChangePassword(input);
            return AjaxResult(cmdResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [IgnoreAntiforgeryToken]
        public async Task<JavaScriptResult> SetIsActive(string id, bool isActive)
        {
            var cmdResult = await _userApiService.SetIsActive(id, isActive);
            return AjaxResult(cmdResult);
        }



        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
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
