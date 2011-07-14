using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackDragon.Providers
{
    static class FontProvider
    {
        private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();

        public static void AddFont(string name, SpriteFont font)
        {
            fonts.Add(name, font);
        }

        public static SpriteFont GetFont(string name)
        {
            return fonts[name];
        }
    }
}
