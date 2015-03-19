using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    class PillarContainer : GameObject
    {
        private Random      _random;

        public List<Pillar> Pillars { get; set; }
        public float        Speed { get; set; }

        public PillarContainer(Game game, Vector2 position)
            : base(game, position)
        {
            Texture = AssetsManager.BackgroundBottom;
            Speed = 1.4f;
        }

        public override void Initialize()
        {
            Pillars = new List<Pillar>();
            _random = new Random();

            for (int i = 0; i < 3; i++)
            {
                Pillars.Add(new Pillar(
                                    Game,
                                    new Vector2( i * 400.0f + 200, _random.Next(-300, 0)),
                                    this));
            }

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X - Speed, Position.Y);

            if (Position.X - Speed <= -(Texture.Width - Game.GraphicsDevice.Viewport.Width)) Position = new Vector2(Speed, Position.Y);

            base.Update(gameTime);
        }
    }
}
