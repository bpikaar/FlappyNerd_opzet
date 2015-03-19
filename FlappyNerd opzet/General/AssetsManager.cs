using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyNerd_opzet
{
    public static class AssetsManager
    {
        public static Dictionary<BirdState, Texture2D>   BirdTextures { get; set; }
        public static Dictionary<BirdState, SoundEffect> BirdSounds   { get; set; }

        public static Texture2D     ButtonStart;
        public static Texture2D     Background;
        public static Texture2D     BackgroundBottom;
        public static Texture2D     Pillar;

        public static SpriteFont    Verdana;

        public static void LoadContent(Game game)
        {
            BirdTextures    = new Dictionary<BirdState, Texture2D>();
            BirdSounds      = new Dictionary<BirdState, SoundEffect>();
            
            BirdTextures.Add(BirdState.Up   , game.Content.Load<Texture2D>("bird_wings_up"));
            BirdTextures.Add(BirdState.Down , game.Content.Load<Texture2D>("bird_wings_down"));

            ButtonStart     = game.Content.Load<Texture2D>("ButtonStart");
            Background      = game.Content.Load<Texture2D>("Background");
            BackgroundBottom= game.Content.Load<Texture2D>("Background_bottom");
            Pillar          = game.Content.Load<Texture2D>("Pillar");

            // Sounds
            BirdSounds.Add(BirdState.Up,    game.Content.Load<SoundEffect>("FlapUp"));
            BirdSounds.Add(BirdState.Down,  game.Content.Load<SoundEffect>("FlapDown"));

            // Fonts
            Verdana             = game.Content.Load<SpriteFont>("Verdana"); //14
        }
    }
}
