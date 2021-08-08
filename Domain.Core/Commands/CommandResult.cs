namespace TaskoMask.Domain.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(string message, string id = "")
        {
            EntityId = id;
            Message = message;
        }

        public string EntityId { get; private set; }
        public string Message { get; private set; }
       
    }

}