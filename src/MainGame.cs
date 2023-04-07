using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GoingTerminal.Core;
using GoingTerminal.Entities;

namespace GoingTerminal;

internal sealed class MainGame : Game {
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Camera _camera;
    private Player _player;
    private List<Sprite> _sprites;

    internal static int ScreenWidth = 1920;
    internal static int ScreenHeight = 1080;

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

        _camera = new Camera();
        var playerTexture = Content.Load<Texture2D>("placeholder");

        _player = new Player(playerTexture) {
            Position = new Vector2(100, 100),
        };

        _sprites = new List<Sprite>() { };
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _camera.Follow(_player);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin(transformMatrix: _camera.Transform);

        _player.Draw(_spriteBatch);

        foreach (var sprite in _sprites) {
            sprite.Draw(_spriteBatch);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
