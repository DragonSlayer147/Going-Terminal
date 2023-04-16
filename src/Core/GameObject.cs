using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GoingTerminal.Core;

/// <summary>
/// Represents an object in a scene.
/// </summary>
public sealed class GameObject {
    private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();

    internal GameObject() : this(null, Array.Empty<Type>()) { }

    internal GameObject(string name) : this(name, Array.Empty<Type>()) { }

    internal GameObject(string name, params Type[] components) {
        Name = name;

        foreach (var type in components) {
            if (!type.IsSubclassOf(typeof(Component)))
                throw new ArgumentException($"Provided type ('{type}') does not inherit from Component");

            AddComponentInternal(type);
        }

        SceneManager.SceneObjectManager.AddRootGameObject(this);
        Scene = SceneManager.GetActiveScene();
        AddComponent<Transform>();
        SetActive(true);
    }

    internal bool IsActive { get; private set; }

    internal string Tag { get; set; }

    /// <summary>
    /// A layer 0 to 31, determines rendering order (renders from 0 -> 31).
    /// </summary>
    internal byte Layer { get; set; }

    internal Scene Scene { get; }

    internal string Name { get; set; }

    internal Transform Transform => GetComponent<Transform>();

    /// <summary>
    /// Searches the active <see cref="Scene" /> for a <see cref="GameObject" /> with the given tag.
    /// Only returns the first found, so only use this method when expecting exactly one result. Use FindGameObjectsWithTag otherwise.
    /// Returns null if no <see cref="GameObject" /> with the given tag was found.
    /// </summary>
    internal static GameObject FindWithTag(string tag) {
        var gameObjectsWithTag = FindGameObjectsWithTag(tag);

        if (gameObjectsWithTag.Length == 0)
            return null;
        else
            return gameObjectsWithTag[0];
    }

    /// <summary>
    /// Searches the active <see cref="Scene" /> for all GameObjects with the given tag.
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    internal static GameObject[] FindGameObjectsWithTag(string tag) {
        var scene = SceneManager.GetActiveScene();
        var gameObjects = SceneManager.SceneObjectManager.GetRootGameObjects(scene.Name);

        return gameObjects.Where(g => g.Tag == tag).ToArray();
    }

    /// <summary>
    /// Makes this <see cref="GameObject" /> visible/loaded.
    /// Superseded if the scene that owns this <see cref="GameObject" /> is not loaded.
    /// </summary>
    internal void SetActive(bool active) => IsActive = active;

    /// <summary>
    /// Creates a new <see cref="Component" /> of type <typeparam name="T" />.
    /// Returns a reference to the newly created <see cref="Component" />.
    /// </summary>
    internal T AddComponent<T>() where T : Component, new() {
        AddComponentInternal(typeof(T));
        return _components[typeof(T)] as T;
    }

    /// <summary>
    /// Creates a new <see cref="Component" /> of type <typeparam name="T" />.
    /// Returns a reference to the newly created <see cref="Component" />.
    /// The given args are used to assign fields on the <see cref="Component" />.<br/>
    /// For example:
    /// <code>
    /// AddComponent<T>(new { FieldName=3 });
    /// </code>
    /// </summary>
    internal T AddComponent<T>(object args) where T : Component {
        AddComponentInternal(typeof(T));
        var component = _components[typeof(T)] as T;

        foreach (var arg in args.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)) {
            var fieldInfo = typeof(T).GetField(arg.Name, BindingFlags.Public | BindingFlags.Instance);

            if (fieldInfo == null)
                throw new ArgumentException($"Provided field '{arg.Name}' is not an existing public field on the '{typeof(T)}' type");

            fieldInfo.SetValue(component, arg.GetValue(args));
        }

        return component;
    }

    /// <summary>
    /// Gets a reference to a <see cref="Component" /> of type <typeparam name="T" />.
    /// </summary>
    internal T GetComponent<T>() where T : Component {
        return _components[typeof(T)] as T;
    }

    /// <summary>
    /// Gets all Components that inherit from a <see cref="Component" /> type.
    /// </summary>
    internal T[] GetComponents<T>() where T : Component {
        var componentList = new List<T>();

        foreach (var component in _components.Where(p => p.Key.IsSubclassOf(typeof(T))).Select(p => p.Value))
            componentList.Add(component as T);

        return componentList.ToArray();
    }

    private void AddComponentInternal(Type type) {
        // This does not do type checking, so if the provided type does not inherit from Component this will crash at runtime
        _components.Add(type, (dynamic)Activator.CreateInstance(type));
        _components[type].GameObject = this;
    }
}
