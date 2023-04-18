using GoingTerminalEngine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Scenes;

public class MainScene : SceneCreator {
    public MainScene() : base("MainScene") { }

    public override void CreateScene(ContentManager content) {
        // Create the player with a SpriteRenderer component
        var player = new GameObject("Player", typeof(SpriteRenderer));
        // Fetch the player sprite
        var playerTexture = content.Load<Texture2D>("placeholder");
        var spriteRenderer = player.GetComponent<SpriteRenderer>();
        // Give the SpriteRenderer the sprite so it can render it
        spriteRenderer.Sprite = new Sprite(playerTexture);
        // Add the PlayerMovement script, makes WASD move the player
        player.AddComponent<Scripts.PlayerMovement>(new {
            speed = 4
        });

        // Create the camera with the required Camera component
        var camera = new GameObject("Camera", typeof(Camera)) {
            // Required tag so the engine treats this as a Camera
            Tag = "MainCamera"
        };
        // Add the FollowPlayer script
        // Constantly centers the camera over the player
        camera.AddComponent<Scripts.FollowPlayer>(new {
            player = player.Transform
        });
    }
}
