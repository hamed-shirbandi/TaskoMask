using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record OwnerRegistered(string Id, string Email, string Password) : IntegrationEvent;
    public record OwnerRegisterationCompleted(string Id, string Email, string DisplayName) : IntegrationEvent;
    public record OwnerProfileUpdated(string Id, string OldEmail, string NewEmail) : IntegrationEvent;
    public record OwnerUpdatingProfileCompleted(string Id, string Email, string DisplayName) : IntegrationEvent;


    public record OrganizationAdded(string Id, string Name, string Description, string OwnerId) : IntegrationEvent;
    public record OrganizationDeleted(string Id) : IntegrationEvent;
    public record OrganizationUpdated(string Id, string Name, string Description) : IntegrationEvent;


    public record ProjectAdded(string Id, string Name, string Description, string OrganizationId, string OrganizationName, string OwnerId) : IntegrationEvent;
    public record ProjectDeleted(string Id) : IntegrationEvent;
    public record ProjectUpdated(string Id, string Name, string Description) : IntegrationEvent;

}
