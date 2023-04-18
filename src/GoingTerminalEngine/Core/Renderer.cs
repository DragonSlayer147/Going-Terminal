
namespace GoingTerminalEngine;

/// <summary>
/// Represents a <see cref="Component" /> responsible for rendering an object, sprite, ors something else.
/// </summary>
public abstract class Renderer : Component {
    /// <summary>
    /// Creates a <see cref="Renderer" />.
    /// Renderers are enabled by default
    /// </summary>
    protected Renderer() {
        Enabled = true;
    }

    /// <summary>
    /// If the <see cref="Renderer" /> should render when called.
    /// Setting this to <c>false</c> will make objects invisible.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Renders an object, sprite, or something else.
    /// </summary>
    internal abstract void Render();
}
