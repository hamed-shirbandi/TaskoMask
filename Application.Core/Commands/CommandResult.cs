namespace TaskoMask.Application.Core.Commands
{

    public class CommandResult
    {

        public string EntityId { get; private set; }
        public string SuccessMessage { get; private set; }

        public CommandResult()
        {

        }
        public CommandResult(string id, string message)
        {
            EntityId = id;
            SuccessMessage = message;
        }
    }

}