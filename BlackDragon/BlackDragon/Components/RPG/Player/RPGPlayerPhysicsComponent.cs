﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerPhysicsComponent : PhysicsComponent
    {
        public override void Update(GameObject obj, GameTime gameTime)
        {
            
        }

        public override void Receive(string message)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "PHYSICS")
            {

            }
        }
    }
}
