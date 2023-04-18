using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoingTerminalEngine;

/// <summary>
/// The <see cref="Game" /> that houses everything.
/// </summary>
public sealed class Engine : Game {
    private Type[] _sceneCreators;

    /// <summary>
    /// Creates an <see cref="Engine" />.
    /// Can pass SceneCreators which create Scenes before the first update frame.
    /// </summary>
    /// <param name="sceneCreators">Every Type must inherit from <see cref="SceneCreator" />.</param>
    public Engine(params Type[] sceneCreators) {
        Screen.GraphicsDeviceManager = new GraphicsDeviceManager(this) {
            PreferredBackBufferWidth = 1920,
            PreferredBackBufferHeight = 1080,
            IsFullScreen = true
        };

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnResize;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _sceneCreators = sceneCreators;

        foreach (var type in _sceneCreators) {
            if (!type.IsSubclassOf(typeof(SceneCreator)))
                throw new ArgumentException($"Provided type ('{type}') does not inherit from SceneCreator");
        }
    }

    protected override void Initialize() {
        // Any engine setup code goes here
        SpriteRenderer.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Screen.GraphicsDevice = GraphicsDevice;
        Screen.Window = Window;

        base.Initialize();
    }

    protected override void LoadContent() {
        foreach (var sceneCreator in _sceneCreators)
            (Activator.CreateInstance(sceneCreator) as SceneCreator).CreateScene(Content);
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Time.DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        foreach (var scene in SceneManager.GetLoadedScenes()) {
            foreach (var gameObject in scene.GetRootGameObjects()) {
                foreach (var component in gameObject.GetComponents<MonoBehavior>()) {
                    if (component.Enabled)
                        component.Update();
                }
            }
        }

        SceneManager.UpdateScenes();

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
