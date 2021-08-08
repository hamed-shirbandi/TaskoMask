using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Core.Queries
{

    public abstract class BaseQueryHandler
    {
        #region Fields

        protected readonly IDomainNotificationHandler _notifications;
        protected readonly IMapper _mapper;


        #endregion


        #region constructors


        protected BaseQueryHandler(IMapper mapper, IDomainNotificationHandler notifications)
        {
            _mapper = mapper;
            _notifications = notifications;
        }


        #endregion


        #region Protected Methods


        protected void NotifyValidationError(string key, string error)
        {
            _notifications.Add(key, error);
        }


        #endregion
    }
}