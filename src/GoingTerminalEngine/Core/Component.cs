
namespace GoingTerminalEngine;

/// <summary>
/// Represents a piece of <see cref="Core.GameObject" />.
/// </summary>
public abstract class Component : Object {
    protected Component() { }

    /// <summary>
    /// The <see cref="Core.GameObject" /> that owns this <see cref="Component" />.
    /// </summary>
    public GameObject GameObject { get; set; }

    /// <summary>
    /// The owning GameObject's transform.
    /// </summary>
    public Transform Transform => GameObject.Transform;

    /// <summary>
    /// Gets a sibling component off of the owning <see cref="GameObject" />.
    /// </summary>
    public T GetComponent<T>() where T : Component => GameObject.GetComponent<T>();
}
