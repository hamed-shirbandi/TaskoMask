using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record TaskAdded(string Id, string Title, string Description, string CardId, string BoardId) : IntegrationEvent;
    public record TaskDeleted(string Id) : IntegrationEvent;
    public record TaskUpdated(string Id, string Title, string Description) : IntegrationEvent;
    public record TaskMovedToAnotherCard(string TaskId, string CardId) : IntegrationEvent;



    public record CommentAdded(string Id, string Content, string TaskId) : IntegrationEvent;
    public record CommentDeleted(string Id) : IntegrationEvent;
    public record CommentUpdated(string Id, string Content) : IntegrationEvent;


}
