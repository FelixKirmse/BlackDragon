using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using BlackDragon.Providers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Helpers;

namespace BlackDragon.Components.RPG.Player
{
    class RPGPlayerGraphicsComponent : AnimatedGraphicsComponent
    {  
        private bool noInput;
        private string faceDirection;

        public RPGPlayerGraphicsComponent()
        {
            this.currentAnimation = "IdleDown";
            this.animations = AnimationDictionaryProvider.GetRPGPlayerAnimations();
            this.drawDepth = .85f;
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            string newAnimation = "";
            if (noInput)
            {
                switch (faceDirection)
                { 
                    case "Up":
                        newAnimation = "IdleUp";
                        break;
                    
                    case "Down":
                        newAnimation = "IdleDown";
                        break;

                    case "Side":
                        newAnimation = "IdleSide";
                        break;

                    case "UpSide":
                        newAnimation = "IdleUpSide";
                        break;

                    case "DownSide":
                        newAnimation = "IdleDownSide";
                        break;
                }               
                              
                if (newAnimation != currentAnimation)
                {
                    receivedAnimation = newAnimation;
                    PlayAnimation(newAnimation);
                }
            }
            else
            {
                if (receivedAnimation != currentAnimation)
                {                    
                    PlayAnimation(receivedAnimation);
                    receivedAnimation = currentAnimation;
                }
            }  

            noInput = false;
            obj.Send("INPUT_SET_FLIPPED", flipped);

            base.Update(obj, gameTime);
        }        

        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "GRAPHICS")
            {

                if (messageParts[1] == "FACE")
                {
                    if (obj is string)
                        faceDirection = (string)(object)obj;
                }                

                if (messageParts[1] == "NOINPUT")
                {
                    noInput = true;
                }
            }

            base.Receive<T>(message, obj);
        }
    }
}
