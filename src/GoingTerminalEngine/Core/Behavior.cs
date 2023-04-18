
namespace GoingTerminalEngine;

/// <summary>
/// Represents a <see cref="Component" /> that can be enabled/disabled.
/// </summary>
public abstract class Behavior : Component {
    /// <summary>
    /// Creates a <see cref="Behavior" />.
    /// Is enabled by default.
    /// </summary>
    protected Behavior() {
        Enabled = true;
    }

    /// <summary>
    /// If set to <c>true</c>, this <see cref="Component" /> will be updated.
    /// </summary>
    public bool Enabled { get; set; }
}
