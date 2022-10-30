using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record OwnerRegistered(string Id, string Email, string Password) : IntegrationEvent;
    public record OwnerRegisterationCompleted(string Id, string Email, string DisplayName) : IntegrationEvent;
    public record OwnerProfileUpdated(string Id, string OldEmail, string NewEmail) : IntegrationEvent;
    public record OwnerUpdatingProfileCompleted(string Id, string Email, string DisplayName) : IntegrationEvent;


    public record OrganizatonAdded(string Id, string Name, string Description, string OwnerId) : IntegrationEvent;
    public record OrganizatonDeleted(string Id) : IntegrationEvent;
    public record OrganizatonUpdated(string Id, string Name, string Description) : IntegrationEvent;


    public record ProjectAdded(string Id, string Name, string Description, string OrganizatonId, string OwnerId) : IntegrationEvent;
    public record ProjectDeleted(string Id) : IntegrationEvent;
    public record ProjectUpdated(string Id, string Name, string Description) : IntegrationEvent;

}
