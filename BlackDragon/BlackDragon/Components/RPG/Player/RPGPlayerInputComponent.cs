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
            
            if (InputMapper.UP)
                obj.Velocity += new Vector2(0, -obj.Speed);
            if (InputMapper.LEFT)
                obj.Velocity += new Vector2(-obj.Speed, 0);
            if (InputMapper.DOWN)
                obj.Velocity += new Vector2(0, obj.Speed);
            if (InputMapper.RIGHT)
                obj.Velocity += new Vector2(obj.Speed, 0);
            
           
            //if(obj.Velocity != Vector2.Zero)
              //  obj.Velocity.Normalize();

            desiredPosition += obj.Velocity;
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
