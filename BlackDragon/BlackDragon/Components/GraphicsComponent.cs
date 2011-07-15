using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Entities;

namespace BlackDragon.Components
{
    abstract class GraphicsComponent : Component
    {
        public abstract void Draw(GameObject obj, SpriteBatch spriteBatch);        
        public override void Receive<T>(string message, T obj)
        {
        }
    }
}
