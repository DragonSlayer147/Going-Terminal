using Microsoft.Xna.Framework.Input;

namespace GoingTerminalEngine;

/// <summary>
/// Represents the keys used to indicate specified actions.
/// </summary>
public record struct Input {
    /// <summary>
    /// An <see cref="Input" /> where all controls are unmapped.
    /// </summary>
    public static Input None = new Input() {
        Up = Keys.None,
        Down = Keys.None,
        Left = Keys.None,
        Right = Keys.None,
    };

    /// <summary>
    /// The key that controls going up.
    /// </summary>
    public Keys Up;

    /// <summary>
    /// The key that controls going down.
    /// </summary>
    public Keys Down;

    /// <summary>
    /// The key that controls going left.
    /// </summary>
    public Keys Left;

    /// <summary>
    /// The key that controls going right.
    /// </summary>
    public Keys Right;
}
