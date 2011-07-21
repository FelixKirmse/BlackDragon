using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Entities;
using BlackDragon.Helpers;

namespace BlackDragon.Components
{
    class AnimatedGraphicsComponent : GraphicsComponent
    {
        protected Dictionary<string, AnimationStrip> animations;
        protected bool flipped;
        protected string currentAnimation = "Idle";
        protected string receivedAnimation;

        public override void Draw(GameObject obj, SpriteBatch spriteBatch)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (flipped)
                effects = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(
                animations[currentAnimation].Texture,
                obj.Position,
                animations[currentAnimation].FrameRectangle,
                Color.White,
                0,
                Vector2.Zero,
                1,
                effects,
                0.85f);
        }

        public override void Update(GameObject obj, GameTime gameTime)
        {
            updateAnimation(gameTime);
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
                            animations = (Dictionary<string, AnimationStrip>)(object)obj;
                    }

                    if (messageParts[2] == "FLIPPED")
                    {
                        if (obj is bool)
                            flipped = (bool)(object)obj;
                    }                    
                }

                if (messageParts[1] == "PLAYANIMATION")
                {
                    receivedAnimation = messageParts[2];
                }                
            }        
        }

        protected void updateAnimation(GameTime gameTime)
        {
            if (animations.ContainsKey(currentAnimation))
            {
                if (animations[currentAnimation].FinishedPlaying)
                {
                    PlayAnimation(animations[currentAnimation].NextAnimation);
                }
                else
                {
                    animations[currentAnimation].Update(gameTime);
                }
            }
        }

        protected void PlayAnimation(string name)
        {
            if (name != null && animations.ContainsKey(name))
            {
                currentAnimation = name;
                animations[name].Play();
            }
        }
    }
}
