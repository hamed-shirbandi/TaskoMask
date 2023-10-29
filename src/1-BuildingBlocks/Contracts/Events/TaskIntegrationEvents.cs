namespace TaskoMask.BuildingBlocks.Contracts.Events;

public record TaskAdded(string Id, string Title, string Description, string CardId, string BoardId) : IIntegrationEvent;

public record TaskDeleted(string Id) : IIntegrationEvent;

public record TaskUpdated(string Id, string Title, string Description) : IIntegrationEvent;

public record TaskMovedToAnotherCard(string TaskId, string CardId) : IIntegrationEvent;

public record CommentAdded(string Id, string Content, string TaskId) : IIntegrationEvent;

public record CommentDeleted(string Id) : IIntegrationEvent;

public record CommentUpdated(string Id, string Content) : IIntegrationEvent;
