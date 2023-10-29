namespace TaskoMask.BuildingBlocks.Contracts.Events;

public record UserRegistered(string Email) : IIntegrationEvent;

public record UserUpdated(string Email) : IIntegrationEvent;
