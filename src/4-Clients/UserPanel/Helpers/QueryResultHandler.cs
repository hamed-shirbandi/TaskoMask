using Blazored.Modal;
using Blazored.Toast.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Clients.UserPanel.Helpers;

public class QueryResultHandler<T>
{
    public QueryResultHandler() { }

    private Result<T> result;
    private MessageType messageType;

    public static QueryResultHandler<T> Init()
    {
        return new QueryResultHandler<T>();
    }

    public QueryResultHandler<T> WithResult(Result<T> result)
    {
        this.result = result;
        return this;
    }

    public QueryResultHandler<T> WithComponentMessageType(MessageType messageType)
    {
        this.messageType = messageType;
        return this;
    }

    public QueryResultHandler<T> ShowToas(IToastService toastService)
    {
        if (result.IsSuccess)
            toastService.ShowSuccess(result.Message, "");
        else
            toastService.ShowError(result.Errors.ParseToFragment(), result.Message);
        return this;
    }

    public QueryResultHandler<T> ShowErrorToast(IToastService toastService)
    {
        if (!result.IsSuccess)
            toastService.ShowError(result.Errors.ParseToFragment(), result.Message);
        return this;
    }

    public QueryResultHandler<T> PublishMessage(IComponentMessageService messageService)
    {
        if (result.IsSuccess)
            messageService.SendMessage(messageType);
        return this;
    }

    public QueryResultHandler<T> CloseModal(BlazoredModalInstance modalInstance)
    {
        modalInstance.CloseAsync();
        return this;
    }
}
