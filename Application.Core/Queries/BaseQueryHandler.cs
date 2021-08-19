using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Core.Queries
{


    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseQueryHandler
    {
        #region Fields

        protected readonly IDomainNotificationHandler _notifications;
        protected readonly IMapper _mapper;


        #endregion


        #region Ctors


        protected BaseQueryHandler(IMapper mapper, IDomainNotificationHandler notifications)
        {
            _mapper = mapper;
            _notifications = notifications;
        }


        #endregion


        #region Protected Methods


        /// <summary>
        /// 
        /// </summary>
        protected void NotifyValidationError(string key, string error)
        {
            _notifications.Add(key, error);
        }


        #endregion
    }
}