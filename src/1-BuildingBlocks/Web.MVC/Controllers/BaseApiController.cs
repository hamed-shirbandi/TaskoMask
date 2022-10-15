using Microsoft.AspNetCore.Mvc;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Services;
using TaskoMask.BuildingBlocks.Web.MVC.Services.AuthenticatedUser;

namespace TaskoMask.BuildingBlocks.Web.MVC.Controllers
{
    public class BaseApiController : Controller
    {
        #region Fields

        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IInMemoryBus _inMemoryBus;
        private readonly INotificationHandler _notifications;

        #endregion

        #region Ctors


        ///TODO delete this ctor after removing monolith service
        public BaseApiController()
        {
        }


        ///TODO delete this ctor after removing monolith service
        public BaseApiController(IAuthenticatedUserService authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
        }


        public BaseApiController(IAuthenticatedUserService authenticatedUserService, IInMemoryBus inMemoryBus, INotificationHandler notifications)
        {
            _authenticatedUserService = authenticatedUserService;
            _inMemoryBus = inMemoryBus;
            _notifications = notifications;
        }



        #endregion

        #region Protected Methods





        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<TCommand>(TCommand cmd) where TCommand : BaseCommand
        {
            var result = await _inMemoryBus.Send(cmd);

            //get notification errors
            var errors = _notifications.GetErrors();

            //result is null when throw application or domain exception 
            if (result == null)
                return Result.Failure<CommandResult>(errors);

            //if there is any notification error so result is failed
            if (errors.Count > 0)
                return Result.Failure<CommandResult>(errors, result.Message);

            return Result.Success(result, result.Message);
        }




        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<TQuery>> SendQueryAsync<TQuery>(BaseQuery<TQuery> query)
        {
            var result = await _inMemoryBus.Send(query);
            if (_notifications.HasAny())
                return Result.Failure<TQuery>(_notifications.GetErrors());

            return Result.Success(result);
        }




        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserName()
        {
            return _authenticatedUserService.GetUserName();
        }



        /// <summary>
        /// 
        /// </summary>
        protected string GetCurrentUserId()
        {
            return _authenticatedUserService.GetUserId();
        }



        #endregion

        #region Private Methods


        #endregion

    }
}