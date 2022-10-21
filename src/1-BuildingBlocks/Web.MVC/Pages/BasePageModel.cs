using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.BuildingBlocks.Web.MVC.Pages
{
    public class BasePageModel: PageModel
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly INotificationHandler _notifications;

        public BasePageModel(IInMemoryBus inMemoryBus, INotificationHandler notifications)
        {
            _inMemoryBus = inMemoryBus;
            _notifications = notifications;
        }





        /// <summary>
        /// 
        /// </summary>
        protected async Task<Result<CommandResult>> SendCommandAsync<TCommand>(TCommand cmd) where TCommand : BaseCommand
        {
            var result = await _inMemoryBus.SendCommand(cmd);

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
            var result = await _inMemoryBus.SendQuery(query);
            if (_notifications.HasAny())
                return Result.Failure<TQuery>(_notifications.GetErrors());

            return Result.Success(result);
        }

    }
}
