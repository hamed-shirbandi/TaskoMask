namespace TaskoMask.BuildingBlocks.Web.MVC.Exceptions;

/// <summary>
///
/// </summary>
public class MessageConsumerFaultException : Exception
{
    public MessageConsumerFaultException(string message)
        : base(message) { }
}
