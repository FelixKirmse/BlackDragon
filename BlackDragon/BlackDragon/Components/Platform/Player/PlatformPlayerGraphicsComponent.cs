using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;

namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerGraphicsComponent : GraphicsComponent
    {
        public override void Draw(GameObject obj, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                VariableProvider.WhiteTexture,
                obj.Position,
                new Rectangle(0, 0, 16, 24),
                Color.Pink,
                0,
                Vector2.Zero,
                1,
                SpriteEffects.None,
                0.85f);
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            
        }

        public override void Receive<T>(string message, T desiredPosition)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "GRAPHICS")
            { 
            
            }
        }
    }
}
