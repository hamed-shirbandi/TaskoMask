using Microsoft.AspNetCore.Mvc;
using TaskoMask.Application.Membership.Operators.Services;

namespace TaskoMask.Presentation.Framework.Web.Components
{
    public class UserMenu : ViewComponent
    {

        #region Fileds

        private readonly IOperatorService _operatorService;


        #endregion

        #region Ctor

        public UserMenu(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserName = User.Identity.Name;
            var @operator = await _operatorService.GetByIdAsync(currentUserName);
            return View(@operator.Value);
        }

        #endregion


    }
}
