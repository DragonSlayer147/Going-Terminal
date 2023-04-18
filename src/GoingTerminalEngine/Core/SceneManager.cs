using System;
using System.Collections.Generic;

namespace GoingTerminalEngine;

/// <summary>
/// Handles creation and modification of scenes.
/// </summary>
public static class SceneManager {
    private static readonly Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();
    private static readonly Dictionary<string, List<GameObject>> _sceneObjects = new Dictionary<string, List<GameObject>>();
    private static readonly HashSet<string> _loadedScenes = new HashSet<string>();

    private static string _active;

    /// <summary>
    /// Creates a new scene with a name (must be unique).
    /// </summary>
    public static void CreateScene(string name) {
        if (_scenes.ContainsKey(name))
            throw new ArgumentException($"A scene already exists with the name '{name}'");

        _scenes.Add(name, new Scene() { IsLoaded = false, Name = name });
        _sceneObjects.Add(name, new List<GameObject>());
    }

    /// <summary>
    /// This is used to keep track of scenes in their intermediate phase when <see cref="LoadScene" /> was called but the scene has not been loaded yet.
    /// </summary>
    internal static HashSet<string> ScenesPreppedForLoading = new HashSet<string>();

    /// <summary>
    /// When <see cref="LoadScene" /> or <see cref="UnloadScene" /> is called, the scenes are not actually unloaded until the end of the next frame.
    /// This prevents single frame black screens.
    /// </summary>
    internal static HashSet<string> ScenesPreppedForUnloading = new HashSet<string>();

    /// <summary>
    /// Gets the active scene.
    /// </summary>
    public static Scene GetActiveScene() {
        if (_active == null)
            throw new ArgumentException("No active scene");

        return _scenes[_active];
    }

    /// <summary>
    /// Changes the current active scene.
    /// </summary>
    public static void SetActiveScene(string name) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        _active = name;
    }

    /// <summary>
    /// Loads an existing scene. Can optionally unload any other loaded scenes by using <see cref="LoadSceneMode.Single" />.
    /// </summary>
    public static void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        ScenesPreppedForUnloading.Remove(name);

        if (mode == LoadSceneMode.Single) {
            ScenesPreppedForLoading.Clear();

            foreach (var loadedScene in _loadedScenes) {
                if (loadedScene == name)
                    continue;

                UnloadScene(name);
            }

            SetActiveScene(name);
        }

        ScenesPreppedForLoading.Add(name);
    }

    /// <summary>
    /// Unloads a single scene.
    /// </summary>
    public static void UnloadScene(string name) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        ScenesPreppedForLoading.Remove(name);
        ScenesPreppedForUnloading.Add(name);
    }

    /// <summary>
    /// Gets a scene by name.
    /// </summary>
    public static Scene GetSceneByName(string name) {
        if (!_scenes.ContainsKey(name))
            throw new ArgumentException($"No such scene with the name '{name}'");

        return _scenes[name];
    }

    /// <summary>
    /// Handles actually unloading and loading scenes.
    /// </summary>
    internal static void UpdateScenes() {
        if (ScenesPreppedForLoading.Count > 0) {
            foreach (var sceneName in ScenesPreppedForLoading) {
                if (_loadedScenes.Contains(sceneName))
                    continue;

                foreach (var gameObject in SceneObjectManager.GetRootGameObjects(sceneName)) {
                    foreach (var component in gameObject.GetComponents<MonoBehavior>()) {
                        if (!component.HasBeenStarted) {
                            component.Start();
                            component.HasBeenStarted = true;
                        }
                    }
                }

                _loadedScenes.Add(sceneName);
                _scenes[sceneName].IsLoaded = true;
            }

            ScenesPreppedForLoading.Clear();
        }

        if (ScenesPreppedForUnloading.Count > 0) {
            foreach (var sceneName in ScenesPreppedForUnloading) {
                if (!_loadedScenes.Contains(sceneName))
                    continue;

                _loadedScenes.Remove(sceneName);
                _scenes[sceneName].IsLoaded = false;
            }

            ScenesPreppedForUnloading.Clear();
        }
    }

    /// <summary>
    /// Gets all loaded scenes. Only to be used by engine classes.
    /// </summary>
    internal static Scene[] GetLoadedScenes() {
        var sceneList = new List<Scene>();

        foreach (var loadedScene in _loadedScenes)
            sceneList.Add(_scenes[loadedScene]);

        return sceneList.ToArray();
    }

    /// <summary>
    /// Manages root GameObjects. Only to be used by engine classes.
    /// </summary>
    internal static class SceneObjectManager {
        /// <summary>
        /// Adds a <see cref="GameObject" /> to the active scene.
        /// </summary>
        internal static void AddRootGameObject(GameObject gameObject) {
            if (_active == null)
                throw new ArgumentException("No active scene to attach the object to");

            _sceneObjects[_active].Add(gameObject);
        }

        /// <summary>
        /// Gets all GameObjects owned by the active scene.
        /// </summary>
        internal static List<GameObject> GetRootGameObjects(string name) {
            if (!_scenes.ContainsKey(name))
                throw new ArgumentException($"No such scene with the name '{name}'");

            return _sceneObjects[name];
        }
    }
}
