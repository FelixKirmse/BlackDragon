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
        #region Player AnimationStrips
        private static Texture2D playerIdlePlatform;
        private static Texture2D playerWalkPlatform;
        private static Texture2D playerJumpUpPlatform;
        private static Texture2D playerJumpDownPlatform;

        private static Texture2D playerIdleSideRPG;
        private static Texture2D playerIdleUpRPG;
        private static Texture2D playerIdleDownRPG;
        private static Texture2D playerIdleDownSideRPG;
        private static Texture2D playerIdleUpSideRPG;

        private static Texture2D playerWalkSideRPG;
        private static Texture2D playerWalkUpRPG;
        private static Texture2D playerWalkDownRPG;
        private static Texture2D playerWalkDownSideRPG;
        private static Texture2D playerWalkUpSideRPG;
        #endregion

        #region NPC AnimationStrips
        #region Maria AnimationStrips
        private static Texture2D mariaIdleSide;
        private static Texture2D mariaIdleUp;
        private static Texture2D mariaIdleDown;
        private static Texture2D mariaIdleDownSide;
        private static Texture2D mariaIdleUpSide;

        private static Texture2D mariaWalkSide;
        private static Texture2D mariaWalkUp;
        private static Texture2D mariaWalkDown;
        private static Texture2D mariaWalkDownSide;
        private static Texture2D mariaWalkUpSide;
        #endregion
        #endregion

        #region Entity AnimationStrips
        private static Texture2D platformWaterTexture;
        #endregion

        #region LoadAnimationStrips
        public static void LoadAnimationStrips(ContentManager Content)
        {
            #region RPGPlayerAnimationStrips
            playerIdleDownRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idledown");
            playerIdleDownSideRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idledownright");
            playerIdleSideRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleright");
            playerIdleUpRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleup");
            playerIdleUpSideRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/idleupright");
            playerWalkDownRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkdown");
            playerWalkDownSideRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkdownright");
            playerWalkSideRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkright");
            playerWalkUpRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkup");
            playerWalkUpSideRPG = Content.Load<Texture2D>(@"textures/Sprites/Player/RPG/walkupright");
            #endregion

            #region PlatformPlayerAnimationStrips
            playerIdlePlatform = Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/idle");
            playerJumpDownPlatform = Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/jumpdown");
            playerJumpUpPlatform = Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/jumpup");
            playerWalkPlatform = Content.Load<Texture2D>(@"textures/Sprites/Player/Platform/walk");
            #endregion            

            #region NPC AnimationStrips
            #region Maria AnimationStrips
            mariaIdleDown = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idledown");
            mariaIdleDownSide = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idledownside");
            mariaIdleSide = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idleside");
            mariaIdleUp = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idleup");
            mariaIdleUpSide = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/idleupside");
            mariaWalkDown = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkdown");
            mariaWalkDownSide = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkdownside");
            mariaWalkSide = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkside");
            mariaWalkUp = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkup");
            mariaWalkUpSide = Content.Load<Texture2D>(@"textures/Sprites/NPCs/Maria/walkupside");
            #endregion
            #endregion

            #region Entities
            platformWaterTexture = Content.Load<Texture2D>(@"textures/misc/water");            
            #endregion
        }
        #endregion

        #region Getters
        #region GetRPGPlayerAnimations
        public static Dictionary<string, AnimationStrip> GetRPGPlayerAnimations()
        {
            Dictionary<string, AnimationStrip> rpgPlayerAnimations = new Dictionary<string, AnimationStrip>();
            rpgPlayerAnimations.Add("IdleSide", new AnimationStrip(playerIdleSideRPG, 20, "IdleSide", true, 0.15f));
            rpgPlayerAnimations.Add("IdleUp", new AnimationStrip(playerIdleUpRPG, 20, "IdleUp", true, 0.15f));
            rpgPlayerAnimations.Add("IdleDown", new AnimationStrip(playerIdleDownRPG, 20, "IdleDown", true, 0.15f));
            rpgPlayerAnimations.Add("IdleUpSide", new AnimationStrip(playerIdleUpSideRPG, 20, "IdleUpSide", true, 0.15f));
            rpgPlayerAnimations.Add("IdleDownSide", new AnimationStrip(playerIdleDownSideRPG, 20, "IdleDownSide", true, 0.15f));
            rpgPlayerAnimations.Add("WalkSide", new AnimationStrip(playerWalkSideRPG, 20, "WalkSide", true, 0.15f));
            rpgPlayerAnimations.Add("WalkDown", new AnimationStrip(playerWalkDownRPG, 20, "WalkDown", true, 0.15f));
            rpgPlayerAnimations.Add("WalkUp", new AnimationStrip(playerWalkUpRPG, 20, "WalkUp", true, 0.15f));
            rpgPlayerAnimations.Add("WalkUpSide", new AnimationStrip(playerWalkUpSideRPG, 20, "WalkUpSide", true, 0.15f));
            rpgPlayerAnimations.Add("WalkDownSide", new AnimationStrip(playerWalkDownSideRPG, 20, "WalkDownSide", true, 0.15f));

            return rpgPlayerAnimations;
        }
        #endregion

        #region GetPlatformPlayerAnimations
        public static Dictionary<string, AnimationStrip> GetPlatformPlayerAnimations()
        {
            Dictionary<string, AnimationStrip> PlatformPlayerAnimations = new Dictionary<string, AnimationStrip>();
            PlatformPlayerAnimations.Add("Idle", new AnimationStrip(playerIdlePlatform, 24, "Idle", true, 0.2f));
            PlatformPlayerAnimations.Add("Walk", new AnimationStrip(playerWalkPlatform, 25, "Walk", true));
            PlatformPlayerAnimations.Add("JumpUp", new AnimationStrip(playerJumpUpPlatform, 18, "JumpUp", true));
            PlatformPlayerAnimations.Add("JumpDown", new AnimationStrip(playerJumpDownPlatform, 25, "JumpDown", true));

            return PlatformPlayerAnimations;
        }
        #endregion

        #region NPC Animation Getters
        #region GetMariaAnimations
        public static Dictionary<string, AnimationStrip> GetMariaAnimations()
        {
            Dictionary<string, AnimationStrip> MariaAnimations = new Dictionary<string, AnimationStrip>();
            MariaAnimations.Add("IdleSide", new AnimationStrip(mariaIdleSide, 17, "IdleSide", true, 0.15f));
            MariaAnimations.Add("IdleUp", new AnimationStrip(mariaIdleUp, 17, "IdleUp", true, 0.15f));
            MariaAnimations.Add("IdleDown", new AnimationStrip(mariaIdleDown, 17, "IdleDown", true, 0.15f));
            MariaAnimations.Add("IdleUpSide", new AnimationStrip(mariaIdleUpSide, 17, "IdleUpSide", true, 0.15f));
            MariaAnimations.Add("IdleDownSide", new AnimationStrip(mariaIdleDownSide, 17, "IdleDownSide", true, 0.15f));
            MariaAnimations.Add("WalkSide", new AnimationStrip(mariaWalkSide, 17, "WalkSide", true, 0.15f));
            MariaAnimations.Add("WalkDown", new AnimationStrip(mariaWalkDown, 17, "WalkDown", true, 0.15f));
            MariaAnimations.Add("WalkUp", new AnimationStrip(mariaWalkUp, 17, "WalkUp", true, 0.15f));
            MariaAnimations.Add("WalkUpSide", new AnimationStrip(mariaWalkUpSide, 17, "WalkUpSide", true, 0.15f));
            MariaAnimations.Add("WalkDownSide", new AnimationStrip(mariaWalkDownSide, 17, "WalkDownSide", true, 0.15f));

            return MariaAnimations;
        }
        #endregion
        #endregion

        #region EntityAnimationGetters
        #region Water
        public static Dictionary<string, AnimationStrip> GetWaterAnimations()
        {
            Dictionary<string, AnimationStrip> WaterAnimations = new Dictionary<string,AnimationStrip>();
            WaterAnimations.Add("Idle", new AnimationStrip(platformWaterTexture, 16, "Idle", true, .5f));
            return WaterAnimations;
        }
        #endregion
        #endregion
        #endregion
    }
}
