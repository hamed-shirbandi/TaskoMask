namespace TaskoMask.Clients.UserPanel.Services.ComponentMessage;

/// <summary>
/// A service to communicate between components
/// </summary>
public class ComponentMessageService : IComponentMessageService
{
    public event Action<MessageType> OnMessage;

    public void SendMessage(MessageType messageType)
    {
        OnMessage?.Invoke(messageType);
    }
}
