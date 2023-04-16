using Microsoft.Xna.Framework.Graphics;
using GoingTerminal.Core;
using Microsoft.Xna.Framework.Content;

namespace GoingTerminal.Scenes;

public class MainScene : SceneCreator {
    public MainScene() : base("MainScene") { }

    public override void CreateScene(ContentManager content) {
        // Create the player
        var playerObject = new GameObject("Player", typeof(Scripts.Player), typeof(SpriteRenderer));
        var playerTexture = content.Load<Texture2D>("placeholder");
        var spriteRenderer = playerObject.GetComponent<SpriteRenderer>();
        spriteRenderer.Sprite = new Sprite(playerTexture);

        // Create the camera
        var mainCamera = new GameObject("Main Camera", typeof(Camera));
        mainCamera.Tag = "MainCamera";
        mainCamera.AddComponent<Scripts.FollowPlayer>(new {
            player = playerObject.Transform,
            size = spriteRenderer.Sprite.Size
        });
    }
}
