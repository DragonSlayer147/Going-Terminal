using Microsoft.Xna.Framework.Input;

namespace GoingTerminalEngine;

public static class Input {
    /// <summary>
    /// Returns <c>true</c> if the provided key is down.
    /// </summary>
    public static bool GetKey(Keys key) {
        return Keyboard.GetState().IsKeyDown(key);
    }
}
