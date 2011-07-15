using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using BlackDragon.Providers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerInputComponent : InputComponent
    {
        public override void Update(GameObject obj)
        {
            Vector2 desiredPosition = obj.Position;
            Vector2 direction = Vector2.Zero;
            
            if (InputMapper.UP)
                direction += new Vector2(0, -1);
            if (InputMapper.LEFT)
                direction += new Vector2(-1, 0);
            if (InputMapper.DOWN)
                direction += new Vector2(0, 1);
            if (InputMapper.RIGHT)
                direction += new Vector2(1, 0);
            
            if(direction != Vector2.Zero)
                direction.Normalize();

            desiredPosition += obj.Velocity * direction;
            obj.Send<Vector2>("PHYSICS_DESIREDPOSITION", desiredPosition);
        }

        public override void Receive<T>(string message, T desiredPosition)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "INPUT")
            {

            }
        }
    }
}
