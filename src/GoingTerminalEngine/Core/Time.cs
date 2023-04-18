
namespace GoingTerminalEngine;

/// <summary>
/// Provides time information.
/// </summary>
public static class Time {
    /// <summary>
    /// Measures how much time has passed since the last update frame, in seconds.
    /// </summary>
    public static float DeltaTime { get; internal set; }
}
