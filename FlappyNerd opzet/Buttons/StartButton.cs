using FlappyNerd_opzet;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    class StartButton : Button
    {
        public StartButton(Game1 game, Vector2 position)
            : base(game, position)
        {
            Texture = AssetsManager.ButtonStart;
        }

        protected override void ButtonAction()
        {
            Game1.StartGame();
            Dispose();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Game.Components.Remove(this); 
            }

            base.Dispose(disposing);
        }
    }
}
