using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminalEngine;

/// <summary>
/// Represents the viewport, not the entire display that is being used.
/// </summary>
public static class Screen {
    /// <summary>
    /// The current resolution of the viewport.
    /// </summary>
    public static Vector2 CurrentResolution => new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);

    internal static GameWindow Window { get; set; }

    internal static GraphicsDeviceManager GraphicsDeviceManager { get; set; }

    internal static GraphicsDevice GraphicsDevice { get; set; }
}
