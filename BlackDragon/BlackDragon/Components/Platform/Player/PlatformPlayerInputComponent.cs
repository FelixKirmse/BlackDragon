using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Entities;


namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerInputComponent : InputComponent
    {

        private float gravity;        
        private bool onGround;
        private int jumpCount;
        private bool noInput;

        public override void Update(GameObject obj)
        {
            noInput = true;
            if (!InputMapper.JUMP && gravity < 0)
            {
                gravity += .45f;
                noInput = false;
            }

            if (gravity < 10)
                gravity += 0.5f;

            if (InputMapper.STRICTJUMP && jumpCount == 1 && gravity > -5)
            {
                gravity = -8;
                jumpCount = 2;
                noInput = false;
            }
            obj.Send<float>("PHYSICS_SET_GRAVITY", gravity);
            obj.Send<GameObject>("PHYSICS_RUN_GRAVITYLOOP", obj);

            if (InputMapper.STRICTJUMP && onGround)
            {
                gravity = -10;
                jumpCount = 1;
                onGround = false;
                obj.Send<bool>("PHYSICS_SET_ONGROUND", false);
                noInput = false;
            }

            if (gravity > 0 && jumpCount != 2)
            {
                jumpCount = 1;
            }

            if (InputMapper.LEFT)
            {
                noInput = false;
                obj.Send<float>("PHYSICS_SET_HORIZ", -3);
                if (onGround)
                {
                    obj.Send<bool>("GRAPHICS_PLAYANIMATION_Walk", true);                    
                }
                obj.Send<bool>("GRAPHICS_SET_FLIPPED", true);
                    
            }
            else if (InputMapper.RIGHT)
            {
                noInput = false;
                obj.Send<float>("PHYSICS_SET_HORIZ", 3);
                if (onGround)
                {
                    obj.Send<bool>("GRAPHICS_PLAYANIMATION_Walk", true);                    
                }
                obj.Send<bool>("GRAPHICS_SET_FLIPPED", false);
            }
            else
            {                
                obj.Send<float>("PHYSICS_SET_HORIZ", 0);
                if (onGround)
                {
                    obj.Send<bool>("GRAPHICS_PLAYANIMATION_Idle", true);                    
                }
            }

            obj.Send<bool>("GRAPHICS_NOINPUT", noInput);
        }

        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "INPUT")
            {
                if (messageParts[1] == "SET")
                {
                    switch (messageParts[2])
                    { 
                        case "GRAVITY":
                            if (obj is float)
                                gravity = (float)(object)obj;
                            break;                       

                        case "ONGROUND":
                            if (obj is bool)
                                onGround = (bool)(object)obj;
                            break;

                        case "JUMPCOUNT":
                            if (obj is int)
                                jumpCount = (int)(object)obj;
                            break;
                    }
                }
            }
        }
    }
}
