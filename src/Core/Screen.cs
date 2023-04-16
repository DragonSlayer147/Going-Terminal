using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

public static class Screen {

    public static Vector2 CurrentResolution => new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height);

    internal static GameWindow Window { get; set; }

    internal static GraphicsDeviceManager GraphicsDeviceManager { get; set; }

    internal static GraphicsDevice GraphicsDevice { get; set; }
}
