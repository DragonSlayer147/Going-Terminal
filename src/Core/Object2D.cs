using Microsoft.Xna.Framework;

namespace GoingTerminal.Core;

/// <summary>
/// Represents an object in the game.
/// </summary>
internal abstract partial class Object2D : GameComponent {
    private Object2D(Game game) : base(game) { }
}
