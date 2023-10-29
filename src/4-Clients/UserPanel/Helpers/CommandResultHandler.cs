using Blazored.Modal;
using Blazored.Toast.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Clients.UserPanel.Helpers;

public class CommandResultHandler
{
    private Result<CommandResult> result;
    private MessageType messageType;

    private CommandResultHandler() { }

    /// <summary>
    ///
    /// </summary>
    public static CommandResultHandler Init()
    {
        return new CommandResultHandler();
    }

    /// <summary>
    ///
    /// </summary>
    public CommandResultHandler WithResult(Result<CommandResult> result)
    {
        this.result = result;
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    public CommandResultHandler WithComponentMessageType(MessageType messageType)
    {
        this.messageType = messageType;
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    public CommandResultHandler ShowToast(IToastService toastService)
    {
        if (result.IsSuccess)
            toastService.ShowSuccess(result.Value.Message, result.Message);
        else
            toastService.ShowError(result.Errors.ParseToFragment(), result.Message);
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    public CommandResultHandler ShowErrorToast(IToastService toastService)
    {
        if (!result.IsSuccess)
            toastService.ShowError(result.Errors.ParseToFragment(), result.Message);
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    public CommandResultHandler PublishMessage(IComponentMessageService messageService)
    {
        if (result.IsSuccess)
            messageService.SendMessage(messageType);
        return this;
    }

    /// <summary>
    ///
    /// </summary>
    public CommandResultHandler CloseModal(BlazoredModalInstance modalInstance)
    {
        if (result.IsSuccess)
            modalInstance.CloseAsync();
        return this;
    }
}
