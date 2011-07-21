using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;
using BlackDragon.Helpers;
using System.Diagnostics;

namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerGraphicsComponent : AnimatedGraphicsComponent
    {        
        private bool onGround;

        public PlatformPlayerGraphicsComponent()
        {
            this.currentAnimation = "Idle";
            this.animations = AnimationDictionaryProvider.PlatformPlayerAnimations;
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            Debug.WriteLine("Current: " + currentAnimation + " Received: " + receivedAnimation);
            if(receivedAnimation == "")
            {
                if (onGround)
                    receivedAnimation = "Idle";
            }
                
            if (receivedAnimation != currentAnimation && receivedAnimation != "")
            {
                PlayAnimation(receivedAnimation);
            }
                        
            receivedAnimation = "";

            base.Update(obj, gameTime);
        }       


        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "GRAPHICS")
            {
                if (messageParts[1] == "SET")
                {   
                    if (messageParts[2] == "ONGROUND")
                    {
                        if (obj is bool)
                            onGround = (bool)(object)obj;
                    }
                } 
            }

            base.Receive<T>(message, obj);
        }
    }
}
