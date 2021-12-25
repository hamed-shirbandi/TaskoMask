namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    /// <summary>
    /// A service to communicate between components
    /// </summary>
    public class MessageService : IMessageService
    {
        public event Action<MessageType> OnMessage;

        public void SendMessage(MessageType messageType)
        {
            OnMessage?.Invoke(messageType);
        }
    }
}
