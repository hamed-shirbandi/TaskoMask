namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    /// <summary>
    /// A service to communicate between components
    /// </summary>
    public class MessageService : IMessageService
    {
        public event Func<MessageType,Task> OnMessage;

        public void SendMessage(MessageType messageType)
        {
            OnMessage?.Invoke(messageType);
        }
    }
}
