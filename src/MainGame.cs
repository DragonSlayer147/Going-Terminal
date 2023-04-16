using System;
using GoingTerminal.Core;
using GoingTerminal.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoingTerminal;

/// <summary>
/// The <see cref="Game" /> that houses everything.
/// </summary>
internal sealed class MainGame : Game {
    internal MainGame() {
        Screen.GraphicsDeviceManager = new GraphicsDeviceManager(this) {
            PreferredBackBufferWidth = 1920,
            PreferredBackBufferHeight = 1080,
            IsFullScreen = true
        };

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnResize;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        // Any Core setup code goes here
        SpriteRenderer.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Screen.GraphicsDevice = GraphicsDevice;
        Screen.Window = Window;

        base.Initialize();
    }

    protected override void LoadContent() {
        // Any game setup code goes here
        new MainScene().CreateScene(Content);

        SceneManager.LoadScene("MainScene");
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

    private void UpdateTitle() {
#if DEBUG
        // Any debug info can go here
        Window.Title = $"Going Terminal (Debug) {Screen.CurrentResolution}";
#else
        Window.Title = "Going Terminal";
#endif
    }

    private void OnResize(object sender, EventArgs e) {
        UpdateTitle();
    }
}
