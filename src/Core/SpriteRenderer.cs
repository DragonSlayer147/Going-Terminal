using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoingTerminal.Core;

internal sealed class SpriteRenderer : Renderer {
    public SpriteRenderer() {
        Color = Color.White;
    }

    internal static SpriteBatch SpriteBatch { get; set; }

    internal Color Color { get; set; }

    internal Sprite Sprite { get; set; }

    internal override void Draw() {
        SpriteBatch.Draw(
            Sprite.Texture,
            Transform.Position,
            null,
            Color,
            Transform.Rotation,
            Vector2.Zero,
            Transform.Zoom,
            SpriteEffects.None,
            GameObject.Layer / 31
        );
    }
}
