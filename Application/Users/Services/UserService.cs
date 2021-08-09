using AutoMapper;
using TaskoMask.Domain.Core.Helpers;
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
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Users.Services
{
    public class UserService : BaseApplicationService, IUserService
    {
        #region Fields

        #endregion

        #region Ctor

        public UserService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion
       
        #region Public Methods




        #endregion

    }

}
