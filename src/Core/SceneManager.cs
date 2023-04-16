using System;
using System.Collections.Generic;

namespace GoingTerminal.Core;

/// <summary>
/// Handles creation and modification of scenes.
/// </summary>
internal static class SceneManager {
    private static readonly Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();
    private static readonly Dictionary<string, List<GameObject>> _sceneObjects = new Dictionary<string, List<GameObject>>();
    private static readonly HashSet<string> _loadedScenes = new HashSet<string>();

    private static string _active;

    /// <summary>
    /// Creates a new scene with a name (must be unique).
    /// </summary>
    internal static void CreateScene(string name) {
        if (_scenes.ContainsKey(name))
            throw new ArgumentException($"A scene already exists with the name '{name}'");

        var isLoaded = false;

        // This ensures that at least 1 scene is loaded.
        if (_scenes.Count == 0) {
            _active = name;
            isLoaded = true;
        }

        _scenes.Add(name, new Scene() { IsLoaded = isLoaded, Name = name });
        _sceneObjects.Add(name, new List<GameObject>());
    }

    /// <summary>
    /// Gets the active scene.
    /// </summary>
    internal static Scene GetActiveScene() {
        if (_scenes.Count == 0)
            throw new ArgumentException("No active scene");

        return _scenes[_active];
    }

    /// <summary>
    /// Changes the current active scene.
    /// </summary>
    internal static void SetActiveScene(string name) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        _active = name;
    }

    /// <summary>
    /// Gets a scene by name.
    /// </summary>
    internal static Scene GetSceneByName(string name) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        return _scenes[name];
    }

    /// <summary>
    /// Loads an existing scene. Can optionally unload any other loaded scenes by using <see cref="LoadSceneMode.Single" />.
    /// </summary>
    internal static void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        // See if the scene has not been loaded and can be loaded
        // Otherwise where already done
        if (_loadedScenes.Add(name)) {
            var gameObjects = SceneObjectManager.GetRootGameObjects(name);



            _scenes[name].IsLoaded = true;
        }

        if (mode == LoadSceneMode.Single) {
            foreach (var loadedScene in _loadedScenes) {
                if (loadedScene == name)
                    continue;

                _loadedScenes.Remove(loadedScene);
                _scenes[loadedScene].IsLoaded = false;
            }
        }
    }

    /// <summary>
    /// Unloads a single scene.
    /// </summary>
    internal static void UnloadScene(string name) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        // See if the scene is loaded an can be unloaded
        // Otherwise where already done
        if (_loadedScenes.Remove(name))
            _scenes[name].IsLoaded = false;
    }

    /// <summary>
    /// Gets all loaded scenes. Only to be used by Core classes.
    /// </summary>
    internal static Scene[] GetLoadedScenes() {
        var sceneList = new List<Scene>();

        foreach (var loadedScene in _loadedScenes)
            sceneList.Add(_scenes[loadedScene]);

        return sceneList.ToArray();
    }

    /// <summary>
    /// Manages root GameObjects. Only to be used by Core classes.
    /// </summary>
    internal static class SceneObjectManager {
        internal static void AddRootGameObject(GameObject gameObject) {
            if (_scenes.Count == 0)
                throw new ArgumentException("No scene to attach the object to");

            _sceneObjects[_active].Add(gameObject);
        }

        internal static List<GameObject> GetRootGameObjects(string name) {
            if (!_scenes.ContainsKey(name))
                throw new ArgumentException($"No such scene with the name '{name}'");

            return _sceneObjects[name];
        }
    }
}
