using Microsoft.Xna.Framework;

namespace GoingTerminal.Core;

/// <summary>
/// A simpler form of the <see cref="GameComponent" /> that does not require a reference to the <see cref="Game" />.
/// </summary>
internal abstract class Component {
    internal abstract void Update(GameTime gameTime);
}
