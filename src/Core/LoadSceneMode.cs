
namespace GoingTerminal.Core;

/// <summary>
/// Different ways to load a scene.
/// </summary>
internal enum LoadSceneMode {
    // Load the scene
    Additive,
    // Load the scene, and also unload any other scenes
    Single,
}
