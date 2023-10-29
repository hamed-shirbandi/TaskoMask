namespace TaskoMask.BuildingBlocks.Contracts.Events;

public record OwnerRegistered(string Id, string Email, string Password) : IIntegrationEvent;

public record OwnerRegisterationCompleted(string Id, string Email, string DisplayName) : IIntegrationEvent;

public record OwnerProfileUpdated(string Id, string OldEmail, string NewEmail) : IIntegrationEvent;

public record OwnerUpdatingProfileCompleted(string Id, string Email, string DisplayName) : IIntegrationEvent;

public record OrganizationAdded(string Id, string Name, string Description, string OwnerId) : IIntegrationEvent;

public record OrganizationDeleted(string Id) : IIntegrationEvent;

public record OrganizationUpdated(string Id, string Name, string Description) : IIntegrationEvent;

public record ProjectAdded(string Id, string Name, string Description, string OrganizationId, string OrganizationName, string OwnerId)
    : IIntegrationEvent;

public record ProjectDeleted(string Id) : IIntegrationEvent;

public record ProjectUpdated(string Id, string Name, string Description) : IIntegrationEvent;
