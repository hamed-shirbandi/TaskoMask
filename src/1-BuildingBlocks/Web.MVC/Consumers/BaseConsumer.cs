using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.BuildingBlocks.Web.MVC.Consumers;

public abstract class BaseConsumer<TEvent> : IConsumer<TEvent>
    where TEvent : class
{
    #region Fields

    protected readonly IRequestDispatcher _requestDispatcher;

    #endregion

    #region Ctors



    public BaseConsumer(IRequestDispatcher requestDispatcher)
    {
        _requestDispatcher = requestDispatcher;
    }

    #endregion

    #region Public Methods



    /// <summary>
    ///
    /// </summary>

    public abstract Task ConsumeMessage(ConsumeContext<TEvent> context);

    /// <summary>
    ///
    /// </summary>
    public async Task Consume(ConsumeContext<TEvent> context)
    {
        await ConsumeMessage(context);
    }

    #endregion

    #region Private Methods


    #endregion
}
