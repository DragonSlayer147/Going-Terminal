using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GoingTerminal.Core;
using GoingTerminal.Entities;
using System.Linq;

namespace GoingTerminal;

/// <summary>
/// The <see cref="Game" /> that houses everything.
/// </summary>
internal sealed class MainGame : Game {
    private static Vector2 _viewPort = new Vector2(1920, 1080);

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Camera2D _camera;
    private Player _player;

    internal MainGame() {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = (int)_viewPort.Y;
        _graphics.PreferredBackBufferWidth = (int)_viewPort.X;
        _graphics.IsFullScreen = true;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
#if DEBUG
        // Any debug info can go here
        Window.Title = $"Going Terminal (Debug) {_viewPort}";
#else
        Window.Title = "Going Terminal";
#endif
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _camera = new Camera2D(ref _viewPort);
        var playerTexture = Content.Load<Texture2D>("placeholder");

        _player = new Player(this, _spriteBatch, playerTexture) {
            Position = new Vector2(100, 100),
            Input = new Input() {
                Left = Keys.A,
                Right = Keys.D,
                Up = Keys.W,
                Down = Keys.S,
            },
            Speed = 4,
        };
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // The order here matters, make sure the player is updated after other components and the camera is updated last.
        foreach (var component in Components.OfType<IUpdateable>())
            component.Update(gameTime);

        _player.Update(gameTime);

        _camera.Follow(_player);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: _camera.Transform);

        _player.Draw(gameTime);

        foreach (var component in Components.OfType<IDrawable>())
            component.Draw(gameTime);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void Dispose(bool disposing) {
        _player.Dispose();
        base.Dispose(disposing);
    }
}
