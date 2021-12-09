namespace TaskoMask.Application.Share.Helpers
{
    public class CommandResult
    {
        public CommandResult(string message = "", string id = "")
        {
            EntityId = id;
            Message = message;
        }

        public string EntityId { get; set; }
        public string Message { get; set; }

    }

}