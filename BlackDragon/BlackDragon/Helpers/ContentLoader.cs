using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;
using BlackDragon.Managers;
using BlackDragon.Providers;

namespace BlackDragon
{
    static class ContentLoader
    {
        public static void LoadContent(ContentManager Content)
        {  
            FontProvider.AddFont("Pericles8", Content.Load<SpriteFont>(@"fonts/pericles8"));
            FontProvider.AddFont("Pericles9", Content.Load<SpriteFont>(@"fonts/pericles9")); 
            FontProvider.AddFont("Pericles14", Content.Load<SpriteFont>(@"fonts/pericles14"));
            FontProvider.AddFont("Pericles21", Content.Load<SpriteFont>(@"fonts/pericles21"));

            PlatformManager.LoadContent(Content.Load<Texture2D>(@"textures/TileSets/platform"));
            RPGManager.LoadContent(Content.Load<Texture2D>(@"textures/TileSets/rpg"));

            TitleScreenManager.LoadContent(Content.Load<Texture2D>(@"textures/misc/TitleScreen"));

            VariableProvider.WhiteTexture = Content.Load<Texture2D>(@"textures/misc/white");

            AnimationDictionaryProvider.LoadAnimations(Content);
        }
    }
}
