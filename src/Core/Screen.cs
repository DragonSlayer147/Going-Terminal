using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

public static class Screen {
    public static Vector2 CurrentResolution;

    internal static GraphicsDeviceManager GraphicsDeviceManager { get; set; }

    internal static GraphicsDevice GraphicsDevice { get; set; }
}
