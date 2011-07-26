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
        private bool faceUp;
        private bool faceDown;
        private bool faceSide;
        private bool noInput;

        public RPGPlayerGraphicsComponent()
        {
            this.currentAnimation = "IdleDown";
            this.animations = AnimationDictionaryProvider.RPGPlayerAnimations;
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            string newAnimation = "";
            if (noInput)
            {
               
                if (faceUp)
                    newAnimation = "IdleUp";
                if (faceDown)
                    newAnimation = "IdleDown";
                if (faceSide)
                    newAnimation = "IdleSide";                
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

            base.Update(obj, gameTime);
        }        

        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "GRAPHICS")
            {      
                if (messageParts[1] == "FACEUP")
                {
                    faceUp = true;
                    faceDown = false;
                    faceSide = false;
                }

                if (messageParts[1] == "FACEDOWN")
                {
                    faceUp = false;
                    faceDown = true;
                    faceSide = false;
                }

                if (messageParts[1] == "FACESIDE")
                {
                    faceUp = false;
                    faceDown = false;
                    faceSide = true;
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
