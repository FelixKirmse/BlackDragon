﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerPhysicsComponent : PhysicsComponent
    {
        public override void Update(GameObject obj, GameTime gameTime)
        {
            
        }

        public override void Receive<T>(string message, T desiredPosition)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "PHYSICS")
            {

            }
        }
    }
}