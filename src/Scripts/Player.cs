using GoingTerminal.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GoingTerminal.Scripts;

public class Player : MonoBehavior {
    private Input input = new Input() {
        Left = Keys.A,
        Right = Keys.D,
        Up = Keys.W,
        Down = Keys.S,
    };

    private float speed = 4;

    public override void Update() {
        var velocity = new Vector2();

        if (Keyboard.GetState().IsKeyDown(input.Up))
            velocity.Y = -speed;
        if (Keyboard.GetState().IsKeyDown(input.Down))
            velocity.Y = speed;
        if (Keyboard.GetState().IsKeyDown(input.Left))
            velocity.X = -speed;
        if (Keyboard.GetState().IsKeyDown(input.Right))
            velocity.X = speed;

        GameObject.Transform.Position += velocity;
    }
}
