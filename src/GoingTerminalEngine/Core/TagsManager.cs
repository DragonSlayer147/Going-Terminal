using System;
using System.Collections.Generic;

namespace GoingTerminalEngine;

/// <summary>
/// Registers and keeps track of objects with specific tags to speed up lookup times.
/// </summary>
public static class TagsManager {
    /// <summary>
    /// A cache containing every registered tag, and all GameObjects with that tag.
    /// </summary>
    internal static Dictionary<string, Dictionary<int, GameObject>> TaggedGameObjectsCache = new Dictionary<string, Dictionary<int, GameObject>>();

    /// <summary>
    /// Registers and new tag.
    /// </summary>
    public static void RegisterTag(string tag) {
        if (!RegisteredTags.Add(tag))
            // Already been registered, early exit
            return;

        TaggedGameObjectsCache.Add(tag, new Dictionary<int, GameObject>());
    }

    /// <summary>
    /// All currently registered/available tags.
    /// </summary>
    public static HashSet<string> RegisteredTags = new HashSet<string>();

    /// <summary>
    /// Adds a tagged object to the cache.
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="gameObject"></param>
    internal static void AddTaggedObject(string tag, GameObject gameObject) {
        if (!RegisteredTags.Contains(tag))
            throw new ArgumentException($"Tag '{tag}' is not a registered tag");

        var id = gameObject.GetInstanceID();

        if (TaggedGameObjectsCache[tag].ContainsKey(id))
            throw new ArgumentException($"GameObject has already been tagged");

        TaggedGameObjectsCache[tag].Add(id, gameObject);
    }

    /// <summary>
    /// Updates as GameObject's tag.
    /// </summary>
    internal static void UpdateTaggedObject(string oldTag, string newTag, GameObject gameObject) {
        if (!RegisteredTags.Contains(oldTag))
            throw new ArgumentException($"Tag '{oldTag}' is not a registered tag");

        if (!RegisteredTags.Contains(newTag))
            throw new ArgumentException($"Tag '{oldTag}' is not a registered tag");

        var id = gameObject.GetInstanceID();

        if (!TaggedGameObjectsCache[oldTag].ContainsKey(id))
            throw new ArgumentException($"GameObject has not been tagged");

        TaggedGameObjectsCache[oldTag].Remove(id);
        TaggedGameObjectsCache[newTag].Add(id, gameObject);
    }

    /// <summary>
    /// Searches the cache for all GameObjects with <param name="tag" /> as their tag.
    /// </summary>
    internal static GameObject[] GetObjectsWithTag(string tag) {
        if (!RegisteredTags.Contains(tag))
            throw new ArgumentException($"Tag '{tag}' is not a registered tag");

        // If this is too slow, can instead return IEnumerable to prevent unnecessary conversions
        var gameObjects = new List<GameObject>(TaggedGameObjectsCache[tag].Values);
        return gameObjects.ToArray();
    }
}
