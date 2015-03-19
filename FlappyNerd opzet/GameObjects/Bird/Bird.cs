using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    class Bird : GameObject
    {
        private const int FLAP_TIME = 200; //Milliseconds
        public  const int MAX_GRAV  = 8; 

        private double   _timeStamp;

        public float     UpForce   { get; set; }
        public bool      Start     { get; set; }
        public BirdState WingState { get; set; }
        public float     Gravity   { get; set; }
        
        public Bird(Game game, Vector2 position, Color color)
            : base(game, position, color)
        {
            WingState    = BirdState.Down;
            Texture      = AssetsManager.BirdTextures[WingState];
        }

        public override void Update(GameTime gameTime)
        {
            // Na een bepaalde tijd (FLAP_TIME) mogen de vleugels weer naar benden en mag een sound afgespeeld worden van de neergaande vleugels
            if ((gameTime.TotalGameTime.TotalMilliseconds - _timeStamp) > FLAP_TIME && WingState == BirdState.Up)
            {
                WingState = BirdState.Down;
                AssetsManager.BirdSounds[WingState].Play();
            }
            // Bepaal het plaatje dat getekend moet worden
            Texture = AssetsManager.BirdTextures[WingState];
            if (Start)
            {

            }

            Position = new Vector2(Position.X, Position.Y + Gravity - UpForce);

            base.Update(gameTime);
        }

        /// <summary>
        /// Moves the bird up
        /// </summary>
        public void Flap(GameTime gameTime)
        {
            if (Start)
            {
                // Timestamp op slaan. Hierna wordt gekeken hoeveel tijd er verstreken is waarna de vleugels weer naar beneden gaan. 
                _timeStamp  = gameTime.TotalGameTime.TotalMilliseconds;
                
                AssetsManager.BirdSounds[WingState].Play();
            }
        }
    }
}
