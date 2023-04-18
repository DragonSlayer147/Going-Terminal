using GoingTerminalEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GoingTerminal.Scripts;

/// <summary>
/// Moves the player using the keyboard and a variable speed.
/// </summary>
public class PlayerMovement : MonoBehavior {
    private PlayerInput input = new PlayerInput() {
        Left = Keys.A,
        Right = Keys.D,
        Up = Keys.W,
        Down = Keys.S,
    };

    public float speed = 4;

    // We don't need to use FixedUpdate here because we are not using a physics system yet
    public override void Update() {
        var velocity = new Vector2();

        if (Input.GetKey(input.Up))
            velocity.Y = -speed;
        if (Input.GetKey(input.Down))
            velocity.Y = speed;
        if (Input.GetKey(input.Left))
            velocity.X = -speed;
        if (Input.GetKey(input.Right))
            velocity.X = speed;

        Transform.Position += velocity * 100 * Time.DeltaTime;
    }
}
