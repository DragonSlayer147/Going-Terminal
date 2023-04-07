using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

internal abstract class Sprite {
    private Texture2D _texture;

    internal Sprite(Texture2D texture) {
        _texture = texture;
        Rectangle = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
    }

    internal Vector2 Position { get; init; }

    internal Rectangle Rectangle { get; }

    internal void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(_texture, Position, Color.White);
    }
}
