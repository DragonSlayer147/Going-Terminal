using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

/// <summary>
/// Represents a drawable texture.
/// </summary>
internal sealed class Sprite {
    internal Sprite(Texture2D texture) {
        Texture = texture;
        Rectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
    }

    /// <param name="rectangle">What portion of the texture to use for the sprite.</param>
    internal Sprite(Texture2D texture, Rectangle rectangle) {
        Texture = texture;
        Rectangle = rectangle;

        TextureRectangle = new Texture2D(Screen.GraphicsDevice, Rectangle.Width, Rectangle.Height);
        var data = new Color[Rectangle.Width * Rectangle.Height];
        Texture.GetData(0, Rectangle, data, 0, data.Length);
        TextureRectangle.SetData(data);
    }

    internal Texture2D Texture { get; }

    internal Rectangle Rectangle { get; }

    internal Texture2D TextureRectangle { get; }

    internal Vector2 Size => new Vector2(Rectangle.Width, Rectangle.Height);
}
