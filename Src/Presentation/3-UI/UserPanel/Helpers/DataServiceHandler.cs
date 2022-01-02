using Blazored.Modal;
using Blazored.Toast.Services;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.UI.UserPanel.Services.Message;

namespace TaskoMask.Presentation.UI.UserPanel.Helpers
{
    public static class DataServiceHandler
    {
        public static void Handle(Result<CommandResult> result, IToastService toastService, IMessageService? messageService = null, MessageType? messageType = null, BlazoredModalInstance? modalInstance = null)
        {
            if (result.IsSuccess)
            {
                //show success notification
                toastService.ShowSuccess(result.Value.Message, result.Message);

                //close the modal if exist
                if (modalInstance != null)
                    modalInstance.CloseAsync();


                //send a message to listeners
                if (messageService != null && messageType != null)
                    messageService.SendMessage(messageType.Value);
            }
            else
                //show failed notification
                toastService.ShowError(result.Errors.ParseToHtml(), result.Message);
        }
    }
}
