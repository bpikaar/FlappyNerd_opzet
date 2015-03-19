using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    class Background : GameObject
    {
        public float Speed { get; set; }

        public Background(Game game, Vector2 position)
            : base(game, position)
        {
            Texture = AssetsManager.Background;
            Speed = 3;
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X - Speed, Position.Y);

            if (Position.X - Speed <= -(Texture.Width - Game.GraphicsDevice.Viewport.Width)) Position = new Vector2(Speed, 0);

            base.Update(gameTime);
        }
    }
}
