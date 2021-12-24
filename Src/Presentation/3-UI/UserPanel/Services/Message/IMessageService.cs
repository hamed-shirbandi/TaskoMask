namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    public interface IMessageService
    {
        event Func<Task> OnMessage;
        void SendMessage();
    }
}
