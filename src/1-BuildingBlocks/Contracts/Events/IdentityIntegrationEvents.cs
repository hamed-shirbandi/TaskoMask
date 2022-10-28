
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record NewUserRegistered(string Id, string UserName, string Email) : IntegrationEvent;

}
