using Microsoft.Xna.Framework.Input;

namespace GoingTerminal.Core;

/// <summary>
/// Represents the keys used to indicate specified actions.
/// </summary>
internal record struct Input {
    internal static Input None = new Input() {
        Up = Keys.None,
        Down = Keys.None,
        Left = Keys.None,
        Right = Keys.None,
    };

    internal Keys Up;

    internal Keys Down;

    internal Keys Left;

    internal Keys Right;
}
