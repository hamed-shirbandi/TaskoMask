using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.web.Components
{
    public class DomainValidationSummary : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;
        public DomainValidationSummary(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = _notifications.GetList().ToList();
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            return View();
        }
    }
}
