using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminalEngine;

/// <summary>
/// Represents a drawable texture.
/// </summary>
public sealed class Sprite {
    private Texture2D _textureRectangle;

    /// <summary>
    /// Creates a <see cref="Sprite" /> using a texture.
    /// The entire <param name="texture" /> is used for rendering.
    /// </summary>
    public Sprite(Texture2D texture) {
        Texture = texture;
        Rectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
    }

    /// <summary>
    /// Creates a <see cref="Sprite" /> using a texture.
    /// Only a portion of the <param name="texture" /> is used for rendering.
    /// <param name="rectangle">What portion of the texture to use for the sprite; the source rectangle.</param>
    /// </summary>
    public Sprite(Texture2D texture, Rectangle rectangle) {
        Texture = texture;
        Rectangle = rectangle;

    }

    /// <summary>
    /// The entire source texture.
    /// </summary>
    public Texture2D Texture { get; }

    /// <summary>
    /// The source rectangle of the texture (the part of the texture to actually use).
    /// </summary>
    public Rectangle Rectangle { get; }

    /// <summary>
    /// The texture used for rendering.
    /// Uses the <see cref="Rectangle" /> to render only a portion of the <see cref="Texture" />.
    /// </summary>
    public Texture2D TextureRectangle {
        get {
            if (_textureRectangle == null) {
                _textureRectangle = new Texture2D(Screen.GraphicsDevice, Rectangle.Width, Rectangle.Height);
                var data = new Color[Rectangle.Width * Rectangle.Height];
                Texture.GetData(0, Rectangle, data, 0, data.Length);
                _textureRectangle.SetData(data);
            }

            return _textureRectangle;
        }
    }

    /// <summary>
    /// The size of the <see cref="Rectangle" />.
    /// </summary>
    public Vector2 Size => new Vector2(Rectangle.Width, Rectangle.Height);
}
