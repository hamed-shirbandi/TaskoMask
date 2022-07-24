using TaskoMask.Presentation.UI.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Presentation.UI.UserPanel.Helpers
{
    public static class ReloadDataHelper
    {

        public static bool Task_Details_Need_Reload(MessageType messageType)
        {
            if (messageType == MessageType.Task_Updated
                || messageType == MessageType.Task_Moved
                || messageType == MessageType.Comment_Created
                || messageType == MessageType.Comment_Updated
                || messageType == MessageType.Comment_Deleted)
                return true;

            return false;
        }


    }
}