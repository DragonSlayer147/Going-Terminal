using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

internal sealed class Camera : Component {
    internal Color BackgroundColor { get; set; }

    internal void Render() {
        Screen.GraphicsDevice.Clear(Color.Black);
        SpriteRenderer.SpriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: GetTransformMatrix());

        var gameObjects = SceneManager.SceneObjectManager.GetRootGameObjects(GameObject.Scene.Name);

        foreach (var gameObject in gameObjects) {
            foreach (var renderer in gameObject.GetComponents<Renderer>())
                renderer.Draw();
        }

        SpriteRenderer.SpriteBatch.End();
    }

    private Matrix GetTransformMatrix() {
        return Matrix.CreateTranslation(new Vector3(-Transform.Position.X, -Transform.Position.Y, 0))
            * Matrix.CreateRotationZ(Transform.Rotation)
            * Matrix.CreateScale(new Vector3(Transform.Zoom, Transform.Zoom, 1));
    }
}
