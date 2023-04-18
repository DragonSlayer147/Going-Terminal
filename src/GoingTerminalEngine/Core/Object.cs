
namespace GoingTerminalEngine;

/// <summary>
/// A base class for all engine classes.
/// </summary>
public abstract class Object {
    private static int _instanceIds = 1;

    private int _instanceId;

    /// <summary>
    /// Creates a new <see cref="Object" />.
    /// </summary>
    protected Object() {
        _instanceId = _instanceIds++;
    }

    /// <summary>
    /// Gets a unique ID for this <see cref="Object" />.
    /// </summary>
    public int GetInstanceID() {
        return _instanceId;
    }
}
