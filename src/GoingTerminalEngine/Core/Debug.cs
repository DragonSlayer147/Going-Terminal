
namespace GoingTerminalEngine;

/// <summary>
/// Debugging tools for development.
/// </summary>
public static class Debug {
    /// <summary>
    /// Logs a message to a debug console.
    /// </summary>
    /// <param name="message"></param>
    public static void Log(string message) {
        System.Diagnostics.Debug.WriteLine(message);
    }

    /// <summary>
    /// Logs a value to a debug console.
    /// </summary>
    /// <param name="value"></param>
    public static void Log(object value) {
        System.Diagnostics.Debug.WriteLine(value);
    }
}
