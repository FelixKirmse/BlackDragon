using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Helpers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BlackDragon.Providers
{
    static class AnimationDictionaryProvider
    {
        public static Dictionary<string, AnimationStrip> PlayerAnimations = new Dictionary<string, AnimationStrip>();

        public static void LoadAnimations(ContentManager Content)
        {
            #region Player Animations
            PlayerAnimations.Add("IdleSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleside"), 19, "IdleSide", true));

            PlayerAnimations.Add("WalkSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkside"), 18, "WalkSide", true));

            PlayerAnimations.Add("WalkDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkdown"), 16, "WalkDown", true));

            PlayerAnimations.Add("WalkUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkup"), 17, "WalkUp", true));

            PlayerAnimations.Add("IdleUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleup"), 17, "IdleUp", true));

            PlayerAnimations.Add("IdleDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idledown"), 16, "IdleDown", true));
            #endregion
        }
    }
}
