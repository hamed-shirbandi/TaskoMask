namespace TaskoMask.Application.Core.Commands
{

    public class CommandResult
    {

        public string EntityId { get; private set; }
        public string SuccessMessage { get; private set; }


        public CommandResult(string message,string id="")
        {
            EntityId = id;
            SuccessMessage = message;
        }
    }

}