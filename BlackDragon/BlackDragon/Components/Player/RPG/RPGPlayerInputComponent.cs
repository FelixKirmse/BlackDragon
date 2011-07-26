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
        private float speed = 2;

        public override void Update(GameObject obj)
        {
            Vector2 desiredPosition = obj.Position;

            if (InputMapper.LEFT)
            {
                obj.Velocity += new Vector2(-speed, 0);
                obj.Send<bool>("GRAPHICS_PLAYANIMATION_WalkSide", true);
                obj.Send<bool>("GRAPHICS_SET_FLIPPED", true);
                obj.Send<bool>("GRAPHICS_FACESIDE", true);
            }
            else if (InputMapper.RIGHT)
            {
                obj.Velocity += new Vector2(speed, 0);
                obj.Send<bool>("GRAPHICS_PLAYANIMATION_WalkSide", true);
                obj.Send<bool>("GRAPHICS_SET_FLIPPED", false);
                obj.Send<bool>("GRAPHICS_FACESIDE", true);
            }
            else if (InputMapper.UP)
            {
                obj.Velocity += new Vector2(0, -speed);
                obj.Send<bool>("GRAPHICS_PLAYANIMATION_WalkUp", true);
                obj.Send<bool>("GRAPHICS_SET_FLIPPED", false);
                obj.Send<bool>("GRAPHICS_FACEUP", true);
            }
            else if (InputMapper.DOWN)
            {
                obj.Velocity += new Vector2(0, speed);
                obj.Send<bool>("GRAPHICS_PLAYANIMATION_WalkDown", true);
                obj.Send<bool>("GRAPHICS_SET_FLIPPED", false);
                obj.Send<bool>("GRAPHICS_FACEDOWN", true);
            }
            else
                obj.Send<bool>("GRAPHICS_NOINPUT", true);
             

            
           
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
