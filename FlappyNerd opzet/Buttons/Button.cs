using FlappyNerd_opzet;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    abstract class Button : GameObject
    {
        private MouseState _previousMouse;
        public Game1 Game1 { get; set; }

        public Button(Game1 game, Vector2 position)
            : base(game, position)
        {
            Game1 = game;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released)
            {
                if (Bounds.Contains(mouse.X, mouse.Y))
                {
                    ButtonAction();
                }
            }

            _previousMouse = mouse;

            base.Update(gameTime);
        }

        protected abstract void ButtonAction();
    }
}
