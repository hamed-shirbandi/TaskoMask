namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    /// <summary>
    /// A service to communicate between components
    /// </summary>
    public class MessageService : IMessageService
    {
        public event Func<Task> OnMessage;

        public void SendMessage()
        {
            OnMessage?.Invoke();
        }
    }
}
