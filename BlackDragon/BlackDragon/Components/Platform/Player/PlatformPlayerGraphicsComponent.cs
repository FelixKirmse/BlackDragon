using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Providers;
using BlackDragon.Helpers;

namespace BlackDragon.Components.Platform.Player
{
    class PlatformPlayerGraphicsComponent : GraphicsComponent
    {
        private Dictionary<string, AnimationStrip> playerAnimations;
        private bool flipped;
        private string currentAnimation = "Idle";
        private string receivedAnimation;
        private bool noInput;
        private bool onGround;

        public override void Draw(GameObject obj, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (flipped)
                effects = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(
                playerAnimations[currentAnimation].Texture,
                obj.Position,
                playerAnimations[currentAnimation].FrameRectangle,
                Color.White,
                0,
                Vector2.Zero,
                1,
                effects,
                0.85f);  
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            
            if(receivedAnimation == "")
            {
                if (onGround)
                    receivedAnimation = "Idle";
            }
                
            if (receivedAnimation != currentAnimation && receivedAnimation != "")
            {
                PlayAnimation(receivedAnimation);
            }
            
            updateAnimation(gameTime);
            receivedAnimation = "";
        }

        private void updateAnimation(GameTime gameTime)
        {
            if (playerAnimations.ContainsKey(currentAnimation))
            {
                if (playerAnimations[currentAnimation].FinishedPlaying)
                {
                    PlayAnimation(playerAnimations[currentAnimation].NextAnimation);
                }
                else
                {
                    playerAnimations[currentAnimation].Update(gameTime);
                }
            }
        }

        public void PlayAnimation(string name)
        {
            if (name != null && playerAnimations.ContainsKey(name))
            {
                currentAnimation = name;
                playerAnimations[name].Play();
            }
        }


        public override void Receive<T>(string message, T obj)
        {
            string[] messageParts = message.Split('_');

            if (messageParts[0] == "GRAPHICS")
            {
                if (messageParts[1] == "SET")
                {
                    if (messageParts[2] == "ANIMATIONS")
                    {
                        if (obj is Dictionary<string, AnimationStrip>)
                            playerAnimations = (Dictionary<string, AnimationStrip>)(object)obj;
                    }

                    if (messageParts[2] == "FLIPPED")
                    {
                        if (obj is bool)
                            flipped = (bool)(object)obj;
                    }

                    if (messageParts[2] == "ONGROUND")
                    {
                        if (obj is bool)
                            onGround = (bool)(object)obj;
                    }
                }

                if (messageParts[1] == "PLAYANIMATION")
                {
                    receivedAnimation = messageParts[2];
                }

                if (messageParts[1] == "NOINPUT")
                {
                    if (obj is bool)
                        noInput = (bool)(object)obj;
                }
            }
        }
    }
}
