﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;
using BlackDragon.Providers;
using BlackDragon.Managers;
using BlackDragon.Entities;
using BlackDragon.Helpers;

namespace BlackDragon.Managers
{
    static class RPGManager
    {
        private static Texture2D rpgTileSet;
        public static GameObject Player { get; private set; }

        public static void LoadContent(Texture2D tileSet)
        {
            rpgTileSet = tileSet;
        }

        public static void Activate()
        {
            TileMap.TileOffset = 0;
            TileMap.DefaultTile = 0;
            TileMap.WhiteTile = 1791;
            TileMap.TransparentTile = 278;
            TileMap.Initialize(rpgTileSet);


            /// temporary code
            if (StateManager.RPGState == StateManager.RPGStates.WORLDMAP)            
                Player = Factory.CreateWorldPlayer();            
            else
                Player = Factory.CreateRPGPlayer();

            Player.Speed = 2;
            Player.Send <Dictionary<string, AnimationStrip>>("GRAPHICS_SET_ANIMATIONS", AnimationDictionaryProvider.PlayerAnimations);
            

            LevelManager.LoadLevel("000");
            CodeManager.CheckCodes(RPGManager.Player);            
                        
        }

        public static void Update(GameTime gameTime)
        {
            if (!StateManager.GamePaused) {
                if (ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
                {
                    StateManager.GameState = StateManager.GameStates.PLATFORM;
                    PlatformManager.Activate();  
                }
                Player.Update(gameTime);
                CodeManager.CheckCodeUnderPlayer(Player);
                GeneralInputManager.HandleGeneralInput();
            }    
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            TileMap.Draw(spriteBatch);
            Player.Draw(spriteBatch);
        }
    }
}
