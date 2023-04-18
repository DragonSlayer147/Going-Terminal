using Microsoft.Xna.Framework.Input;

namespace GoingTerminal;

/// <summary>
/// Represents the keys used to indicate basic actions.
/// </summary>
public record struct PlayerInput {
    /// <summary>
    /// An <see cref="PlayerInput" /> where all controls are unmapped.
    /// </summary>
    public static PlayerInput None = new PlayerInput() {
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
