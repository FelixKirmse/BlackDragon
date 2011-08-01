using System;
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

            VariableProvider.CurrentPlayer = Factory.CreatePlatformPlayer();            
            
            LevelManager.LoadLevel("000");            
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
                EntityManager.Update(gameTime);                
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
