using System.Collections.Generic;
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
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Camera2D _camera;
    private Player _player;
    private List<Component> _components;

    internal int ScreenWidth = 1920;
    internal int ScreenHeight = 1080;

    internal MainGame() {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = ScreenHeight;
        _graphics.PreferredBackBufferWidth = ScreenWidth;
        _graphics.IsFullScreen = true;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _camera = new Camera2D(this);
        var playerTexture = Content.Load<Texture2D>("placeholder");

        _player = new Player(playerTexture) {
            Position = new Vector2(100, 100),
            Input = new Input() {
                Left = Keys.A,
                Right = Keys.D,
                Up = Keys.W,
                Down = Keys.S,
            },
            Speed = 4,
        };

        _components = new List<Component>() { };
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // The order here matters, make sure the player is updated after other components and the camera is updated last.
        foreach (var component in _components)
            component.Update(gameTime);

        _player.Update(gameTime);

        _camera.Follow(_player);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(transformMatrix: _camera.Transform);

        _player.Draw(gameTime, _spriteBatch);

        foreach (var sprite in _components.OfType<Sprite>())
            sprite.Draw(gameTime, _spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
