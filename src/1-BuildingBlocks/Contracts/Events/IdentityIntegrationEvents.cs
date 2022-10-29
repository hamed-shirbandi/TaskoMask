
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record NewUserRegistered(string Email) : IntegrationEvent;

}
