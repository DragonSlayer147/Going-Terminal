
namespace GoingTerminal.Core;

/// <summary>
/// Every user-defined component must inherit from <see cref="MonoBehavior" />.
/// Is an updateabe component.
/// </summary>
public abstract class MonoBehavior : Component {
    public virtual void Start() { }

    public virtual void Update() { }
}
