
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record UserRegistered(string Email) : IntegrationEvent;
    public record UserUpdated(string Email) : IntegrationEvent;

}
