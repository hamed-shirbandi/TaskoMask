using TaskoMask.Clients.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Clients.UserPanel.Helpers;

public static class ReloadDataHelper
{
    public static bool Dashboard_Index_Need_Reload(MessageType messageType)
    {
        if (OrganizationIsChanged(messageType) || ProjectIsChanged(messageType) || BoardIsChanged(messageType))
            return true;

        return false;
    }

    public static bool Project_Index_Need_Reload(MessageType messageType)
    {
        if (BoardIsChanged(messageType))
            return true;

        return false;
    }

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
        return messageType == MessageType.Card_Added || messageType == MessageType.Card_Deleted || messageType == MessageType.Card_Updated;
    }

    private static bool TaskIsChanged(MessageType messageType)
    {
        return messageType == MessageType.Task_Added
            || messageType == MessageType.Task_Deleted
            || messageType == MessageType.Task_Moved
            || messageType == MessageType.Task_Updated;
    }

    private static bool OwnerIsChanged(MessageType messageType)
    {
        return messageType == MessageType.Owner_Updated || messageType == MessageType.Owner_Registered || messageType == MessageType.Owner_Loggedin;
    }

    private static bool BoardIsChanged(MessageType messageType)
    {
        return messageType == MessageType.Board_Added || messageType == MessageType.Board_Deleted || messageType == MessageType.Board_Updated;
    }

    private static bool ProjectIsChanged(MessageType messageType)
    {
        return messageType == MessageType.Project_Added || messageType == MessageType.Project_Deleted || messageType == MessageType.Project_Updated;
    }

    private static bool OrganizationIsChanged(MessageType messageType)
    {
        return messageType == MessageType.Organization_Added
            || messageType == MessageType.Organization_Deleted
            || messageType == MessageType.Organization_Updated;
    }

    private static bool CommentIsChanged(MessageType messageType)
    {
        return messageType == MessageType.Comment_Added || messageType == MessageType.Comment_Deleted || messageType == MessageType.Comment_Updated;
    }
}
