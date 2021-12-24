namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    /// <summary>
    /// A service to communicate between components
    /// </summary>
    public class MessageService : IMessageService
    {
        public event Func<MessageTypeEnum,Task> OnMessage;

        public void SendMessage(MessageTypeEnum messageType)
        {
            OnMessage?.Invoke(messageType);
        }
    }
}
