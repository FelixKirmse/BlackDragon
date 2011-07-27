﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;
using BlackDragon.Managers;
using BlackDragon.Providers;
using BlackDragon.Entities;
using BlackDragon.Helpers;

namespace BlackDragon.Managers
{
    static class PlatformManager
    {
        private static Texture2D platformTileSet;
        public static GameObject Player;

        public static void LoadContent(Texture2D tileSet)
        {
            platformTileSet = tileSet;
        }

        public static void Activate()
        {
            TileMap.TileOffset = 1;
            TileMap.DefaultTile = 125;
            TileMap.WhiteTile = 830;
            TileMap.TransparentTile = 831;
            TileMap.Initialize(platformTileSet);

            Player = Factory.CreatePlatformPlayer();
            
            LevelManager.LoadLevel("000");
            CodeManager.CheckCodes(Player);
         }

        public static void Update(GameTime gameTime)
        {
            if (!StateManager.GamePaused)
            {
                if (ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
                {
                    StateManager.GameState = StateManager.GameStates.RPG;
                    RPGManager.Activate();                    
                }
                Player.Update(gameTime);
                CodeManager.CheckPlayerCodes(Player);
                GeneralInputManager.HandleGeneralInput();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            Player.Draw(spriteBatch);
            TileMap.Draw(spriteBatch);
        }
    }
}
