using System.Collections.Generic;

namespace GoingTerminalEngine;

/// <summary>
/// Represents a view in the game.
/// </summary>
public sealed class Scene {
    /// <summary>
    /// If the scene is currently visible/loaded.
    /// </summary>
    public bool IsLoaded { get; internal set; }

    /// <summary>
    /// The name of the scene.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Gets the GameObjects owned by this scene.
    /// </summary>
    internal List<GameObject> GetRootGameObjects() {
        return SceneManager.SceneObjectManager.GetRootGameObjects(Name);
    }
}
