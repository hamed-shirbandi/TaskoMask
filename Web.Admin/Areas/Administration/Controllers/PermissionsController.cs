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
    public class PermissionsController : BaseMvcController
    {
        #region Fields

        private readonly IRoleService _roleService;

        #endregion

        #region Ctor

        public PermissionsController(IRoleService roleService , IMapper mapper) : base(mapper)
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
            return null;
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
            return null;

        }



        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return null;

        }




        /// <summary>
        /// 
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoleInputDto input)
        {
            return null;

        }





        #endregion

        #region Private Methods



        #endregion


    }
}
