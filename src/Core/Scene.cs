using System.Collections.Generic;

namespace GoingTerminal.Core;

/// <summary>
/// Represents a view in the game.
/// </summary>
internal sealed class Scene {
    /// <summary>
    /// If the scene is currently visible/loaded.
    /// </summary>
    internal bool IsLoaded { get; set; }

    /// <summary>
    /// The name of the scene.
    /// </summary>
    internal string Name { get; set; }

    internal List<GameObject> GetRootGameObjects() {
        return SceneManager.SceneObjectManager.GetRootGameObjects(Name);
    }
}
