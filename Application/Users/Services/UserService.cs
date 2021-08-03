using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Users.Commands.Models;
using TaskoMask.Application.Users.Queries.Models;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Application.Users.Services
{
    public class UserService : BaseApplicationService, IUserService
    {
        #region Fields

        #endregion

        #region Ctor

        public UserService(IMediator mediator, IMapper mapper, INotificationHandler<DomainNotification> notifications) : base(mediator, mapper, notifications)
        { }


        #endregion
       
        #region Public Methods




        #endregion

    }

}
