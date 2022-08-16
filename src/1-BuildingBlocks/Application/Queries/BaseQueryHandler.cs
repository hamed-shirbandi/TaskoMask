using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Notifications;

namespace TaskoMask.BuildingBlocks.Application.Queries
{


    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseQueryHandler
    {
        #region Fields

        protected readonly INotificationHandler _notifications;
        protected readonly IMapper _mapper;


        #endregion


        #region Ctors


        protected BaseQueryHandler(IMapper mapper, INotificationHandler notifications)
        {
            _mapper = mapper;
            _notifications = notifications;
        }


        #endregion


        #region Protected Methods


        /// <summary>
        /// 
        /// </summary>
        protected void NotifyValidationError<TQuery>(BaseQuery<TQuery> request, string error)
        {
            _notifications.Add(request.GetType().Name, error);
        }


        #endregion
    }
}