using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

/// <summary>
/// Represents a <see cref="Component" /> that can be drawn and updated.
/// A simpler option of <see cref="IDrawable" />.
/// </summary>
internal interface IDrawableComponent {
    internal void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}
