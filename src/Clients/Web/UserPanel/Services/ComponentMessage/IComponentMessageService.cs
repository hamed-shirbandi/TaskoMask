﻿namespace TaskoMask.Presentation.UI.UserPanel.Services.ComponentMessage
{
    public interface IComponentMessageService
    {
        event Action<MessageType> OnMessage;
        void SendMessage(MessageType messageType);
    }
}
