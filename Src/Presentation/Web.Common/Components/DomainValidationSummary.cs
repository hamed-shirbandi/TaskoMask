using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Web.Common.Components
{
    public class DomainValidationSummary : ViewComponent
    {
        private readonly IDomainNotificationHandler _notifications;
        public DomainValidationSummary(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            _notifications.GetErrors().ForEach(error => ViewData.ModelState.AddModelError(string.Empty, error));
            return View();
        }
    }
}
