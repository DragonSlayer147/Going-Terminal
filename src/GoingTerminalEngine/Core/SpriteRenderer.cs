using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminalEngine;

/// <summary>
/// Represents a <see cref="Renderer" /> that can draw a <see cref="Core.Sprite" />.
/// </summary>
public sealed class SpriteRenderer : Renderer {
    /// <summary>
    /// Creates a <see cref="SpriteRenderer" />.
    /// The default for <see cref="Color" /> is <see cref="Color.White" />.
    /// <see cref="Sprite" /> must be manually set.
    /// </summary>
    public SpriteRenderer() {
        Color = Color.White;
    }

    internal static SpriteBatch SpriteBatch { get; set; }

    /// <summary>
    /// The <see cref="Core.Sprite" /> that will be drawn when <see cref="Render" /> is called.
    /// </summary>
    public Sprite Sprite { get; set; }

    /// <summary>
    /// The sprite color. Only applicable to some Sprites.
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// Draws <see cref="Sprite" /> using this <see cref="Transform" />.
    /// </summary>
    internal override void Render() {
        SpriteBatch.Draw(
            Sprite.Texture,
            Transform.Position,
            Sprite.Rectangle,
            Color,
            Transform.Rotation,
            new Vector2(Sprite.Size.X / 2, Sprite.Size.Y / 2),
            Transform.Zoom,
            SpriteEffects.None,
            GameObject.Layer / 31
        );
    }
}
