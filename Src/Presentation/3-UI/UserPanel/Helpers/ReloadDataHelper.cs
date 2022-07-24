using TaskoMask.Presentation.UI.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Presentation.UI.UserPanel.Helpers
{
    public static class ReloadDataHelper
    {

        public static bool Task_Details_Need_Reload(MessageType messageType)
        {
            if (TaskIsChanged(messageType) || CommentIsChanged(messageType))
                return true;

            return false;
        }


        public static bool NavMenu_Need_Reload(MessageType messageType)
        {
            if (OwnerIsChanged(messageType))
                return true;

            return false;
        }



        public static bool Board_Index_Need_Reload(MessageType messageType)
        {
            if (CardIsChanged(messageType) || TaskIsChanged(messageType))
                return true;

            return false;
        }
        


        private static bool CardIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Card_Created
                 || messageType == MessageType.Card_Deleted
                 || messageType == MessageType.Card_Updated;
        }


        private static bool TaskIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Task_Created
                || messageType == MessageType.Task_Deleted
                || messageType == MessageType.Task_Moved
                || messageType == MessageType.Task_Updated;
        }


        private static bool OwnerIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Owner_Updated
                 || messageType == MessageType.Owner_Registered
                 || messageType == MessageType.Owner_Loggedin;
        }



        private static bool BoardIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Board_Created
                || messageType == MessageType.Board_Deleted
                || messageType == MessageType.Board_Updated;
        }


        private static bool ProjectIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Project_Created
                || messageType == MessageType.Project_Deleted
                || messageType == MessageType.Project_Updated;
        }


        private static bool OrganizationIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Organization_Created
                || messageType == MessageType.Organization_Deleted
                || messageType == MessageType.Organization_Updated;
        }



        private static bool CommentIsChanged(MessageType messageType)
        {
            return messageType == MessageType.Comment_Created
                || messageType == MessageType.Comment_Deleted
                || messageType == MessageType.Comment_Updated;
        }


    }
}