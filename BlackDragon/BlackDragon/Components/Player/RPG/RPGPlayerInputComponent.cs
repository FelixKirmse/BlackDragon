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
        private float speed = 1.5f;
        bool flipped;

        public override void Update(GameObject obj, GameTime gameTime)
        {            
            string playAnimation = null;            
            string faceDirection = null;

            if (InputMapper.LEFT)
            {
                obj.Velocity += new Vector2(-1, 0);
                playAnimation = "WalkSide";
                flipped = true;
                faceDirection = "Side";
            }
            if (InputMapper.RIGHT)
            {
                obj.Velocity += new Vector2(1, 0);
                playAnimation = "WalkSide";
                flipped = false;
                faceDirection = "Side";
            }
            if (InputMapper.UP)
            {
                obj.Velocity += new Vector2(0, -1);
                playAnimation = "WalkUp";
                flipped = false;
                faceDirection = "Up";
            }
            if (InputMapper.DOWN)
            {
                obj.Velocity += new Vector2(0, 1);
                playAnimation = "WalkDown";
                flipped = false;
                faceDirection = "Down";
            }
             
            if(obj.Velocity == Vector2.Zero)
                obj.Send("GRAPHICS_NOINPUT", true);

            if (InputMapper.UP && InputMapper.RIGHT)
            {
                playAnimation = "WalkUpSide";
                flipped = false;
                faceDirection = "UpSide";
            }

            if (InputMapper.UP && InputMapper.LEFT)
            {
                playAnimation = "WalkUpSide";
                flipped = true;
                faceDirection = "UpSide";
            }

            if (InputMapper.DOWN && InputMapper.RIGHT)
            {
                playAnimation = "WalkDownSide";
                flipped = false;
                faceDirection = "DownSide";
            }

            if (InputMapper.DOWN && InputMapper.LEFT)
            {
                playAnimation = "WalkDownSide";
                flipped = true;
                faceDirection = "DownSide";
            }

            if (InputMapper.LEFT && InputMapper.RIGHT && InputMapper.UP)
            {
                playAnimation = "WalkUp";
                flipped = false;
                faceDirection = "Up";
            }

            if (InputMapper.LEFT && InputMapper.RIGHT && InputMapper.DOWN)
            {
                playAnimation = "WalkDown";
                flipped = false;
                faceDirection = "Down";
            }
            
           
            if(obj.Velocity != Vector2.Zero)
                obj.Velocity.Normalize();
            obj.Velocity *= speed;
            
            obj.Send("GRAPHICS_FACE", faceDirection);
            obj.Send("GRAPHICS_PLAYANIMATION", playAnimation);
            obj.Send("GRAPHICS_SET_FLIPPED", flipped);
        }

        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "INPUT")
            {
                if (messageParts[1] == "SET")
                {
                    if (messageParts[2] == "FLIPPED")
                    {
                        if (obj is bool)
                            flipped = (bool)(object)obj;
                    }
                }
            }
        }
    }
}
