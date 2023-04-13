using Microsoft.Xna.Framework;

namespace GoingTerminal.Core;

internal abstract partial class Object2D {
    /// <summary>
    /// Represents a rectangle object.
    /// </summary>
    internal sealed class Rectangle : Object2D {
        internal Rectangle(Game game, Microsoft.Xna.Framework.Rectangle size) : base(game) { }
    }
}
