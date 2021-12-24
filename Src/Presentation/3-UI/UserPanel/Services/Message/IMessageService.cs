namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    public interface IMessageService
    {
        event Func<MessageType,Task> OnMessage;
        void SendMessage(MessageType messageType);
    }
}
