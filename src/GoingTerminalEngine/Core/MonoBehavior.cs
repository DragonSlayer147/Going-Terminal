
namespace GoingTerminalEngine;

/// <summary>
/// Every user-defined component must inherit from <see cref="MonoBehavior" />.
/// </summary>
public abstract class MonoBehavior : Behavior {
    /// <summary>
    /// Is called on the frame when a script is enabled, before any of the <see cref="Update" /> methods are called the first time.
    /// </summary>
    public virtual void Start() { }

    /// <summary>
    /// Is called every update frame. Because this function is not called at consistent intervals, using
    /// <see cref="Time.DeltaTime" /> is time sensitive calculations is recommended.
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// If <see cref="Start" /> has been called yet.
    /// </summary>
    internal bool HasBeenStarted { get; set; }
}
