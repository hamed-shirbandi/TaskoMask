
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.BuildingBlocks.Contracts.Events
{
    public record BoardAdded(string Id, string Name, string Description, string ProjectId) : IntegrationEvent;
    public record BoardDeleted(string Id) : IntegrationEvent;
    public record BoardUpdated(string Id, string Name, string Description) : IntegrationEvent;


    public record CardAdded(string Id, string Name, BoardCardType Type, string BoardId) : IntegrationEvent;
    public record CardDeleted(string Id) : IntegrationEvent;
    public record CardUpdated(string Id, string Name, BoardCardType Type) : IntegrationEvent;
}
