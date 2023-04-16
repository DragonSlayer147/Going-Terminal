
namespace GoingTerminal.Core;

/// <summary>
/// Debugging tools for development.
/// </summary>
public static class Debug {
    public static void Log(string message) {
        System.Diagnostics.Debug.WriteLine(message);
    }

    public static void Log(object value) {
        System.Diagnostics.Debug.WriteLine(value);
    }
}
