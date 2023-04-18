using Microsoft.Xna.Framework;

namespace GoingTerminalEngine;

/// <summary>
/// Represents a position, zoom, and rotation.
/// </summary>
public sealed class Transform : Component {
    private float _zoom;

    /// <summary>
    /// Creates a default <see cref="Transform" />.
    /// No zoom, no rotation, and the position is set to 0,0.
    /// </summary>
    public Transform() {
        _zoom = 1;
        Rotation = 0;
        Position = Vector2.Zero;
    }

    /// <summary>
    /// The amount of zoom. For example: 1 is no zoom, 2 is zoomed in, 0.5 is zoomed out.
    /// </summary>
    public float Zoom {
        get {
            return _zoom;
        }
        set {
            _zoom = value;

            // A negative zoom will flip the viewport, so not allowed.
            if (_zoom < 0.1f)
                _zoom = 0.1f;
        }
    }

    /// <summary>
    /// The rotation in radians. For example 0 = no rotation, pi/2 = 90 degree rotation.
    /// </summary>
    public float Rotation { get; set; }

    /// <summary>
    /// The parent of this <see cref="Transform" />.
    /// Effectively allows nesting of GameObjects, as this <see cref="Transform" /> is now relative to the parent <see cref="Transform" />.
    /// </summary>
    public Transform Parent { get; set; }

    /// <summary>
    /// The absolute position;
    /// </summary>
    public Vector2 Position {
        get {
            if (Parent != null)
                return Parent.Position + LocalPosition;
            else
                return LocalPosition;
        }
        set {
            if (Parent != null)
                LocalPosition = value - Parent.Position;
            else
                LocalPosition = value;
        }
    }

    /// <summary>
    /// The position relative to <see cref="Parent" />.
    /// If there is no parent, this is the same as <see cref="Position" />.
    /// </summary>
    public Vector2 LocalPosition { get; set; }
}
