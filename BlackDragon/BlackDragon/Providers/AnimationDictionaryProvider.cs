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

        public static Dictionary<string, AnimationStrip> MariaAnimations = new Dictionary<string, AnimationStrip>();

        public static void LoadAnimations(ContentManager Content)
        {
            #region RPG Player Animations  
            RPGPlayerAnimations.Add("IdleSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleright"), 20, "IdleSide", true, 0.15f));

            RPGPlayerAnimations.Add("IdleUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleup"), 20, "IdleUp", true, 0.15f));

            RPGPlayerAnimations.Add("IdleDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idledown"), 20, "IdleDown", true, 0.15f));

            RPGPlayerAnimations.Add("IdleUpSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleupright"), 20, "IdleUpSide", true, 0.15f));

            RPGPlayerAnimations.Add("IdleDownSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idledownright"), 20, "IdleDownSide", true, 0.15f));

            RPGPlayerAnimations.Add("WalkSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkright"), 20, "WalkSide", true, 0.15f));

            RPGPlayerAnimations.Add("WalkDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkdown"), 20, "WalkDown", true, 0.15f));

            RPGPlayerAnimations.Add("WalkUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkup"), 20, "WalkUp", true, 0.15f));

            RPGPlayerAnimations.Add("WalkUpSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkupright"), 20, "WalkUpSide", true, 0.15f));

            RPGPlayerAnimations.Add("WalkDownSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkdownright"), 20, "WalkDownSide", true, 0.15f));
            
            #endregion

            #region Platform Player Animations
            PlatformPlayerAnimations.Add("Idle", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/idle"), 24, "Idle", true, 0.2f));            

            PlatformPlayerAnimations.Add("Walk", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/walk"), 25, "Walk", true));

            PlatformPlayerAnimations.Add("JumpUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/jumpup"), 18, "JumpUp", true));

            PlatformPlayerAnimations.Add("JumpDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/jumpdown"), 25, "JumpDown", true));
            #endregion

            #region NPC Animations
            #region Maria Animations
            MariaAnimations.Add("IdleSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idleside"), 20, "IdleSide", true, 0.15f));

            MariaAnimations.Add("IdleUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idleup"), 20, "IdleUp", true, 0.15f));

            MariaAnimations.Add("IdleDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idledown"), 20, "IdleDown", true, 0.15f));

            MariaAnimations.Add("IdleUpSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idleupside"), 20, "IdleUpSide", true, 0.15f));

            MariaAnimations.Add("IdleDownSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idledownside"), 20, "IdleDownSide", true, 0.15f));

            MariaAnimations.Add("WalkSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkside"), 20, "WalkSide", true, 0.15f));

            MariaAnimations.Add("WalkDown", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkdown"), 20, "WalkDown", true, 0.15f));

            MariaAnimations.Add("WalkUp", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkup"), 20, "WalkUp", true, 0.15f));

            MariaAnimations.Add("WalkUpSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkupside"), 20, "WalkUpSide", true, 0.15f));

            MariaAnimations.Add("WalkDownSide", new AnimationStrip(Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkdownside"), 20, "WalkDownSide", true, 0.15f));
            #endregion
            #endregion
        }
    }
}
