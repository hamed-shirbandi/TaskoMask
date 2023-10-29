using System;

namespace TaskoMask.BuildingBlocks.Application.Notifications;

/// <summary>
///
/// </summary>
public class Notification
{
    public Notification(string key, string value)
    {
        Id = Guid.NewGuid();
        Key = key;
        Value = value;
    }

    /// <summary>
    ///
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// group of notification messages
    /// </summary>
    public string Key { get; private set; }

    /// <summary>
    /// notification message
    /// </summary>
    public string Value { get; private set; }
}
