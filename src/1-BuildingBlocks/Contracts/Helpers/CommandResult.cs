namespace TaskoMask.BuildingBlocks.Contracts.Helpers
{
    public class CommandResult
    {
        public CommandResult(string message = "", string entityId = "")
        {
            EntityId = entityId;
            Message = message;
        }
     

        public string EntityId { get; set; }
        public string Message { get; set; }

    }

}