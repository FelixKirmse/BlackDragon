using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Entities;

namespace BlackDragon.Components
{
    abstract class PhysicsComponent : Component
    {
        public override void Update(GameObject obj, GameTime gameTime) { }      
        public override void Receive<T>(string message, T obj)
        {
        }
    }
}
