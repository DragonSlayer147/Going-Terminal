using Microsoft.Xna.Framework.Input;

namespace GoingTerminal.Core;

/// <summary>
/// Represents the keys used to indicate specified actions.
/// </summary>
public record struct Input {
    public static Input None = new Input() {
        Up = Keys.None,
        Down = Keys.None,
        Left = Keys.None,
        Right = Keys.None,
    };

    public Keys Up;

    public Keys Down;

    public Keys Left;

    public Keys Right;
}
