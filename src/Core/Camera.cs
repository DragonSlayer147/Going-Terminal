using Microsoft.Xna.Framework;

namespace GoingTerminal.Core;

internal sealed class Camera {
    internal Matrix Transform { get; private set; }

    internal void Follow(Sprite target) {
        var position = Matrix.CreateTranslation(
          -target.Position.X - (target.Rectangle.Width / 2),
          -target.Position.Y - (target.Rectangle.Height / 2),
          0);

        var offset = Matrix.CreateTranslation(
            MainGame.ScreenWidth / 2,
            MainGame.ScreenHeight / 2,
            0);

        Transform = position * offset;
    }
}
