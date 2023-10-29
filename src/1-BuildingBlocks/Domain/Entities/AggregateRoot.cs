using System;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Domain.Events;

namespace TaskoMask.BuildingBlocks.Domain.Entities;

/// <summary>
///
/// </summary>
public abstract class AggregateRoot : Entity
{
    #region Fields

    private List<DomainEvent> domainEvents;

    #endregion

    #region Ctors

    public AggregateRoot()
    {
        SetVersion();
    }

    #endregion

    #region Properties

    /// <summary>
    /// To handle concurrency
    /// Vesion changes after each aggregate update
    /// </summary>
    public string Version { get; private set; }

    public IReadOnlyCollection<DomainEvent> DomainEvents => domainEvents?.AsReadOnly();

    #endregion

    #region Public Methods


    /// <summary>
    /// Clear domain events
    /// </summary>
    public void ClearDomainEvents()
    {
        domainEvents?.Clear();
    }

    #endregion

    #region Protected Methods



    /// <summary>
    /// Add domain event
    /// </summary>
    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        CheckInvariants();

        UpdateAggregate();

        domainEvents ??= new List<DomainEvent>();
        domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Check invariants for each entity
    /// Invariants are kind of validation that made the entity in true state
    /// Should be Called in the end of process for the entity
    /// </summary>
    protected abstract void CheckInvariants();

    #endregion

    #region Private Methods


    /// <summary>
    /// update aggregate Version and ModifiedDateTime
    /// </summary>
    private void UpdateAggregate()
    {
        SetVersion();
    }

    /// <summary>
    /// Vesion must change after each aggregate update
    /// </summary>
    private void SetVersion()
    {
        Version = Guid.NewGuid().ToString();
    }

    #endregion
}
