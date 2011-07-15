using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;
using BlackDragon.Providers;
using BlackDragon.Managers;
using BlackDragon.Entities;

namespace BlackDragon.Managers
{
    static class RPGManager
    {
        private static Texture2D rpgTileSet;        

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
        }

        public static void Update(GameTime gameTime)
        {
            if (!StateManager.GamePaused) {
                if (ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
                {
                    StateManager.GameState = StateManager.GameStates.PLATFORM;
                    PlatformManager.Activate();
                    LevelManager.LoadLevel("000");
                }
                GeneralInputManager.HandleGeneralInput();
            }    
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            TileMap.Draw(spriteBatch);
        }
    }
}
