namespace TaskoMask.Presentation.UI.UserPanel.Services.Message
{
    public interface IMessageService
    {
        event Func<MessageTypeEnum,Task> OnMessage;
        void SendMessage(MessageTypeEnum messageType);
    }
}
