
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record UserRegistered(string Email) : IntegrationEvent;

}
