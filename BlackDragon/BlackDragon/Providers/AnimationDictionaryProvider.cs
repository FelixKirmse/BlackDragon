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
        public static Dictionary<string, AnimationStrip> RPGPlayerAnimations = new Dictionary<string, AnimationStrip>();
        public static Dictionary<string, AnimationStrip> PlatformPlayerAnimations = new Dictionary<string, AnimationStrip>();

        public static void LoadAnimations(ContentManager Content)
        {
            #region RPG Player Animations
            RPGPlayerAnimations.Add("IdleSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleside"), 19, "IdleSide", true));

            RPGPlayerAnimations.Add("WalkSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkside"), 18, "WalkSide", true));

            RPGPlayerAnimations.Add("WalkDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkdown"), 16, "WalkDown", true));

            RPGPlayerAnimations.Add("WalkUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkup"), 17, "WalkUp", true));

            RPGPlayerAnimations.Add("IdleUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleup"), 17, "IdleUp", true));

            RPGPlayerAnimations.Add("IdleDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idledown"), 16, "IdleDown", true));
            #endregion

            #region Platform Player Animations
            PlatformPlayerAnimations.Add("Idle", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/idle"), 24, "Idle", true, 0.2f));            

            PlatformPlayerAnimations.Add("Walk", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/walk"), 25, "Walk", true));

            PlatformPlayerAnimations.Add("JumpUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/jumpup"), 18, "JumpUp", true));

            PlatformPlayerAnimations.Add("JumpDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/jumpdown"), 25, "JumpDown", true));
            #endregion
        }
    }
}
