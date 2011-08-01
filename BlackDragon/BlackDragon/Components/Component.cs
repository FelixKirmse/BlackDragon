using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;

namespace BlackDragon.Components
{
    abstract class Component
    {        
        public abstract void Receive<T>(string message, T obj);
        public abstract void Update(GameObject obj, GameTime gameTime);
    }
}
