using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.Application.Administration.Operators.Services;

namespace TaskoMask.Web.Common.Components
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
            var @operator = await _operatorService.GetBaseUserByUserNameAsync(currentUserName);
            return View(@operator.Value);
        }

        #endregion


    }
}
