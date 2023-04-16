using GoingTerminal.Core;
using Microsoft.Xna.Framework.Content;

namespace GoingTerminal.Scenes;

/// <summary>
/// Represents a class created by the user that creates all the content of a scene.
/// </summary>
public abstract class SceneCreator {
    protected SceneCreator(string name) {
        SceneManager.CreateScene(name);
        SceneManager.SetActiveScene(name);
    }

    public abstract void CreateScene(ContentManager content);
}
