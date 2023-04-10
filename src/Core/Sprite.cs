using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

/// <summary>
/// Represents a <see cref="Component" /> with a drawable texture, position, and rectangle.
/// </summary>
internal abstract class Sprite : Component, IDrawableComponent {
    private readonly Texture2D _texture;

    private Rectangle? _rectangle;

    protected Sprite(Texture2D texture) {
        _texture = texture;
        Color = Color.White;
    }

    /// <summary>
    /// Absolute position of the sprite.
    /// </summary>
    internal Vector2 Position { get; set; }

    internal Color Color { get; set; }

    /// <summary>
    /// Automatically calculated rectangle "hitbox" of the sprite.
    /// Uses the size of the given texture and <see cref="Position" />.
    /// </summary>
    internal Rectangle Rectangle {
        get {
            if (_rectangle == null)
                _rectangle = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);

            return _rectangle.Value;
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
        spriteBatch.Draw(_texture, Position, Color.White);
    }

    internal override void Update(GameTime gameTime) { }
}
