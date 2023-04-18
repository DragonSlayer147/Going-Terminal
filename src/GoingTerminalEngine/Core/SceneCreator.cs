using Microsoft.Xna.Framework.Content;

namespace GoingTerminalEngine;

/// <summary>
/// Represents a class created by the user that creates all the content of a scene.
/// </summary>
public abstract class SceneCreator {
    /// <summary>
    /// Creates and activates a new scene.
    /// </summary>
    /// <param name="name">The name of the new scene (must be unique).</param>
    protected SceneCreator(string name) {
        SceneManager.CreateScene(name);
        SceneManager.LoadScene(name);
        SceneManager.SetActiveScene(name);
    }

    /// <summary>
    /// Loads all of the content for the scene.
    /// </summary>
    public abstract void CreateScene(ContentManager content);
}
