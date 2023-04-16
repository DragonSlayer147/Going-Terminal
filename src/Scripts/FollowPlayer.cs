using GoingTerminal.Core;
using Microsoft.Xna.Framework;

namespace GoingTerminal.Scripts;

public class FollowPlayer : MonoBehavior {
    public Transform player;
    public Vector2 size;

    public override void Update() {
        // Centers the camera over the player
        Transform.Position = new Vector2(
            player.Position.X + size.X * 0.5f - Screen.CurrentResolution.X * 0.5f,
            player.Position.Y + size.Y * 0.5f - Screen.CurrentResolution.Y * 0.5f
        );
    }
}
