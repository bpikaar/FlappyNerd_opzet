using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    class Pillar : GameObject
    {
        private PillarContainer _pillarContainer;
        private float           _speed;
        private Random          _random;

        public Rectangle HitArea1
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    0,
                    Texture.Width,
                    (int)((Texture.Height / 2 - 55) + Position.Y));
            }
        }

        public Rectangle HitArea2
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    HitArea1.Bottom + 110,
                    Texture.Width,
                    Texture.Height / 2
                    );
            }
        }

        public Pillar(Game game, Vector2 position, PillarContainer pillarContainer)
            : base(game, position)
        {
            Texture             = AssetsManager.Pillar;
            _pillarContainer    = pillarContainer;
            Position            = position;
            _speed              = 1.4f;
            _random             = new Random();
        }

        

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X - _speed, Position.Y);


            if ((Position.X + Texture.Width) < 0)
            {
                Position = new Vector2(Position.X + 1200, _random.Next(-300, 0));
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Game1.DEBUG)
            {
                Texture2D text = new Texture2D(Game.GraphicsDevice, 1, 1);
                text.SetData(new[] { Color.Yellow });

                Game1.spriteBatch.Draw(text, HitArea1, Color.White);
                Game1.spriteBatch.Draw(text, HitArea2, Color.White);
            }
            base.Draw(gameTime);
        }
        
    }
}
