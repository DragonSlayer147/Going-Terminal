using Microsoft.Xna.Framework.Graphics;
using GoingTerminal.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GoingTerminal.Entities;

/// <summary>
/// Represents a <see cref="Sprite" /> that can move at a variable speed.
/// </summary>
internal sealed class Player : Sprite {
    internal Player(Texture2D texture) : base(texture) {
        Input = Input.None;
        Speed = 0;
    }

    /// <summary>
    /// The given inputs that control the various movements of the player.
    /// </summary>
    internal Input Input { get; init; }

    /// <summary>
    /// The speed of the player, updates the player position every frame.
    /// </summary>
    internal float Speed { get; init; }

    internal override void Update(GameTime gameTime) {
        var velocity = new Vector2();

        if (Keyboard.GetState().IsKeyDown(Input.Up))
            velocity.Y = -Speed;
        if (Keyboard.GetState().IsKeyDown(Input.Down))
            velocity.Y = Speed;
        if (Keyboard.GetState().IsKeyDown(Input.Left))
            velocity.X = -Speed;
        if (Keyboard.GetState().IsKeyDown(Input.Right))
            velocity.X = Speed;

        Position += velocity;
    }
}
