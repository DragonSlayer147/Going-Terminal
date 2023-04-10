using Microsoft.Xna.Framework;

namespace GoingTerminal.Core;

/// <summary>
/// Provides a viewport following a <see cref="Sprite" />. Supports zoom and rotation.
/// </summary>
internal class Camera2D {
    private float _zoom;
    private readonly Vector2 _viewPort;

    internal Camera2D(ref Vector2 viewPort) {
        _viewPort = viewPort;
        _zoom = 1.0f;
        Rotation = 0;
        Position = Vector2.Zero;
    }

    /// <summary>
    /// How much the camera is zoomed in. For example: 1 is no zoom, 2 is zoomed in, 0.5 is zoomed out.
    /// </summary>
    internal float Zoom {
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
    /// The rotation of the camera in radians. For example 0 = no rotation, pi/2 = 90 degree rotation.
    /// </summary>
    internal float Rotation { get; set; }

    /// <summary>
    /// The absolute position of the camera;
    /// </summary>
    internal Vector2 Position { get; private set; }

    /// <summary>
    /// A transform matrix that can be applied to a <see cref="Microsoft.Xna.Framework.Graphics.SpriteBatch.Begin" /> call
    /// to use the viewport.
    /// </summary>
    internal Matrix Transform {
        get {
            return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0))
                * Matrix.CreateRotationZ(Rotation)
                * Matrix.CreateScale(new Vector3(Zoom, Zoom, 1))
                * Matrix.CreateTranslation(new Vector3(_viewPort.X * 0.5f, _viewPort.Y * 0.5f, 0));
        }
    }

    /// <summary>
    /// Move the camera a fixed amount.
    /// </summary>
    internal void Move(Vector2 transform) {
        Position += transform;
    }

    /// <summary>
    /// Updates the transform matrix to center around <param name="target" />.
    /// </summary>
    internal void Follow(Sprite target) {
        Position = new Vector2(
            target.Position.X + (target.Rectangle.Width / 2),
            target.Position.Y + (target.Rectangle.Height / 2)
        );
    }
}
