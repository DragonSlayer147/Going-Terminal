using GoingTerminalEngine;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Scenes;

public class MainScene : SceneCreator {
    public MainScene() : base("MainScene") { }

    public override void CreateScene(ContentManager content) {
        // Create the player
        var player = new GameObject("Player", typeof(SpriteRenderer));
        var playerTexture = content.Load<Texture2D>("placeholder");
        var spriteRenderer = player.GetComponent<SpriteRenderer>();
        spriteRenderer.Sprite = new Sprite(playerTexture);

        player.AddComponent<Scripts.PlayerMovement>(new {
            speed = 4
        });

        // Create the camera
        var camera = new GameObject("Camera", typeof(Camera)) {
            // Required tag so the engine treats this as a Camera
            Tag = "MainCamera"
        };

        camera.AddComponent<Scripts.FollowPlayer>(new {
            player = player.Transform
        });
    }
}
