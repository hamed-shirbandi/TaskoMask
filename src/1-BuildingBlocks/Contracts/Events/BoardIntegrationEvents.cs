using TaskoMask.BuildingBlocks.Contracts.Enums;

namespace TaskoMask.BuildingBlocks.Contracts.Events;

public record BoardAdded(string Id, string Name, string Description, string ProjectId) : IIntegrationEvent;

public record BoardDeleted(string Id) : IIntegrationEvent;

public record BoardUpdated(string Id, string Name, string Description) : IIntegrationEvent;

public record CardAdded(string Id, string Name, BoardCardType Type, string BoardId) : IIntegrationEvent;

public record CardDeleted(string Id) : IIntegrationEvent;

public record CardUpdated(string Id, string Name, BoardCardType Type) : IIntegrationEvent;
