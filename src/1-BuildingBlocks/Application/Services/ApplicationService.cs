using System;
using AutoMapper;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Bus;

namespace TaskoMask.BuildingBlocks.Application.Services
{
    public abstract class ApplicationService : IApplicationService
    {
        #region Fields


        protected readonly IInMemoryBus _inMemoryBus;
        protected readonly IMapper _mapper;
        protected readonly INotificationHandler _notifications;


        #endregion

        #region Ctors


        public ApplicationService(IInMemoryBus inMemoryBus, IMapper mapper, INotificationHandler notifications)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
            _notifications = notifications;

        }



        #endregion


        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        #endregion
    }
}