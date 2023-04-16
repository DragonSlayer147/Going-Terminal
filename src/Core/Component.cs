
namespace GoingTerminal.Core;

public abstract class Component {
    protected Component() { }

    public GameObject GameObject { get; set; }

    public Transform Transform => GameObject.Transform;

    public T GetComponent<T>() where T : Component => GameObject.GetComponent<T>();
}
