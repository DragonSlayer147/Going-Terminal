using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminalEngine;

/// <summary>
/// Represents a <see cref="Component" /> that handles calling Renderers to display GameObjects to the screen.
/// </summary>
public sealed class Camera : Component {
    /// <summary>
    /// Creates a <see cref="Camera" />.
    /// The default background color is <see cref="Color.Black" />.
    /// </summary>
    public Camera() {
        BackgroundColor = Color.Black;
    }

    /// <summary>
    /// The farthest back layer, a single solid color.
    /// </summary>
    public Color BackgroundColor { get; set; }

    /// <summary>
    /// Renders all GameObjects in the <see cref="Scene" /> that owns this <see cref="Camera" />.
    /// </summary>
    internal void Render() {
        Screen.GraphicsDevice.Clear(Color.Black);
        SpriteRenderer.SpriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: GetTransformMatrix());

        var gameObjects = GameObject.Scene.GetRootGameObjects();

        foreach (var gameObject in gameObjects) {
            foreach (var renderer in gameObject.GetComponents<Renderer>())
                renderer.Render();
        }

        SpriteRenderer.SpriteBatch.End();
    }

    private Matrix GetTransformMatrix() {
        return Matrix.CreateTranslation(
                new Vector3(
                    -Transform.Position.X + Screen.CurrentResolution.X * 0.5f,
                    -Transform.Position.Y + Screen.CurrentResolution.Y * 0.5f,
                    0
                ))
            * Matrix.CreateRotationZ(Transform.Rotation)
            * Matrix.CreateScale(
                new Vector3(
                    Transform.Zoom,
                    Transform.Zoom,
                    1
                ));
    }
}
