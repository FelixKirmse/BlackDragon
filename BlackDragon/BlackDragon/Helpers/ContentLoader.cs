using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BlackDragonEngine.TileEngine;
using BlackDragonEngine.Managers;
using BlackDragonEngine.Providers;
using BlackDragon.Providers;
using BlackDragon.Managers;

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
            FontProvider.AddFont("Mono14", Content.Load<SpriteFont>(@"fonts/mono14"));
            FontProvider.AddFont("Mono21", Content.Load<SpriteFont>(@"fonts/mono21"));

            PlatformManager.LoadContent(Content.Load<Texture2D>(@"textures/TileSets/platform"));
            RPGManager.LoadContent(Content.Load<Texture2D>(@"textures/TileSets/rpg"));

            TitleScreenManager.LoadContent(Content.Load<Texture2D>(@"textures/misc/TitleScreen"));

            VariableProvider.WhiteTexture = Content.Load<Texture2D>(@"textures/misc/white");

            AnimationDictionaryProvider.LoadAnimationStrips(Content);

            MugShotProvider.DummyMugShotAngry = Content.Load<Texture2D>(@"textures/misc/mugshots/dummyangry");
            MugShotProvider.DummyMugShotNormal = Content.Load<Texture2D>(@"textures/misc/mugshots/dummynormal");

            DialogManager.Initialize();            
        }
    }
}
