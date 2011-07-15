using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Managers;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerPhysicsComponent : PhysicsComponent
    {
        private Vector2 desiredPosition;

        public override void Update(GameObject obj, GameTime gameTime)
        {
            obj.Position = desiredPosition;
        }

        public override void Receive<T>(string message, T desiredPosition)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "PHYSICS")
            {
                if (messageParts[1] == "DESIREDPOSITION")
                {
                    if (desiredPosition is Vector2)
                        this.desiredPosition = (Vector2)(object)desiredPosition;
                    else
                        return;
                }
            }
        }        
    }
}
