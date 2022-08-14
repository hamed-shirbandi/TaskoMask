using Microsoft.AspNetCore.Mvc;
using TaskoMask.Services.Monolith.Application.Membership.Operators.Services;
using TaskoMask.Services.Monolith.Domain.Core.Services;

namespace TaskoMask.Services.Monolith.Presentation.UI.AdminPanle.Components
{
    public class UserMenu : ViewComponent
    {

        #region Fileds

        private readonly IOperatorService _operatorService;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        #endregion

        #region Ctor

        public UserMenu(IOperatorService operatorService, IAuthenticatedUserService authenticatedUserService)
        {
            _operatorService = operatorService;
            _authenticatedUserService = authenticatedUserService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var operatorId = _authenticatedUserService.GetUserId();
            var @operator = await _operatorService.GetByIdAsync(operatorId);
            return View(@operator.Value);
        }


        #endregion


    }
}
