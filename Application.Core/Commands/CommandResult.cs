namespace TaskoMask.Application.Core.Commands
{

    public class CommandResult
    {

        public string EntityId { get; private set; }
        public string Message { get; private set; }


        public CommandResult(string message,string id="")
        {
            EntityId = id;
            Message = message;
        }
    }

}