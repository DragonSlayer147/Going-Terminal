using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GoingTerminal.Core;
using GoingTerminal.Scenes;

namespace GoingTerminal;

/// <summary>
/// The <see cref="Game" /> that houses everything.
/// </summary>
internal sealed class MainGame : Game {
    internal MainGame() {
        Screen.CurrentResolution = new Vector2(1920, 1080);
        Screen.GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Screen.GraphicsDeviceManager.PreferredBackBufferHeight = (int)Screen.CurrentResolution.Y;
        Screen.GraphicsDeviceManager.PreferredBackBufferWidth = (int)Screen.CurrentResolution.X;
        Screen.GraphicsDeviceManager.IsFullScreen = true;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
#if DEBUG
        // Any debug info can go here
        Window.Title = $"Going Terminal (Debug) {Screen.CurrentResolution}";
#else
        Window.Title = "Going Terminal";
#endif

        SpriteRenderer.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Screen.GraphicsDevice = GraphicsDevice;

        base.Initialize();
    }

    protected override void LoadContent() {
        new MainScene().CreateScene(Content);
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        foreach (var scene in SceneManager.GetLoadedScenes()) {
            foreach (var gameObject in SceneManager.SceneObjectManager.GetRootGameObjects(scene.Name)) {
                foreach (var component in gameObject.GetComponents<MonoBehavior>())
                    component.Update();
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        var camera = GameObject.FindWithTag("MainCamera");

        if (camera == null)
            // Fallback if there is no camera
            Screen.GraphicsDevice.Clear(Color.Black);
        else
            camera.GetComponent<Camera>().Render();

        base.Draw(gameTime);
    }

    protected override void Dispose(bool disposing) {
        base.Dispose(disposing);
    }
}
