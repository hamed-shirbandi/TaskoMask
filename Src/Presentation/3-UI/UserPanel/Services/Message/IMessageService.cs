namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    public interface IMessageService
    {
        event Action<MessageType> OnMessage;
        void SendMessage(MessageType messageType);
    }
}
