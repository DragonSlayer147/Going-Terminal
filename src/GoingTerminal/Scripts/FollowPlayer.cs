using GoingTerminalEngine;

namespace GoingTerminal.Scripts;

/// <summary>
/// Moves the camera to be centered over the player.
/// </summary>
public class FollowPlayer : MonoBehavior {
    public Transform player;

    public override void Update() {
        Transform.Position = player.Position;
    }
}
