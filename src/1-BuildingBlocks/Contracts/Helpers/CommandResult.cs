namespace TaskoMask.BuildingBlocks.Contracts.Helpers
{
    public class CommandResult
    {
        //TODO set this ctor private after removing monolith service
        public CommandResult(string message = "", string entityId = "")
        {
            EntityId = entityId;
            Message = message;
        }


        public static CommandResult Create(string message = "", string entityId = "")
        {
            return new CommandResult(message, entityId);
        }


        public string EntityId { get; }
        public string Message { get; }

    }

}