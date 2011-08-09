using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using Microsoft.Xna.Framework.Graphics;

namespace BlackDragon.Menus
{
    class MenuLabel
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        private SpriteFont font;

        public MenuLabel(string text, string fontName)
        {
            Text = text;
            font = FontProvider.GetFont(fontName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(
                font,
                Text,
                ShortcutProvider.Vector2Point(Position),
                Color.White,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                .2f);
        }
        
    }
}
