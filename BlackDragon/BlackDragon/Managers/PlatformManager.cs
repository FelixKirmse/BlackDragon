using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BlackDragonEngine.TileEngine;
using BlackDragonEngine.Managers;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Entities;
using BlackDragon.Helpers;
using BlackDragon.Providers;

namespace BlackDragon.Managers
{
    static class PlatformManager
    {
        private static Texture2D platformTileSet;        

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
            GameVariableProvider.SaveState.CurrentMode = GameStates.Platform;

            VariableProvider.CurrentPlayer = Factory.CreatePlatformPlayer();            
         }

        public static void Update()
        {
            if (!StateManager.GamePaused)
            {
                EntityManager.Update();                
                GeneralInputManager.HandleGeneralInput();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            EntityManager.Draw(spriteBatch);
            TileMap.Draw(spriteBatch);
        }
    }
}
