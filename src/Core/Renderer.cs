
namespace GoingTerminal.Core;

internal abstract class Renderer : Component {
    protected Renderer() { }

    internal bool Enabled => GameObject.IsActive;

    internal abstract void Draw();
}
