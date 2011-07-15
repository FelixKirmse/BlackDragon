using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tile_Engine;
using BlackDragon.Managers;
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
            TileMap.DefaultTile = 475;
            TileMap.WhiteTile = 830;
            TileMap.TransparentTile = 831;
            TileMap.Initialize(platformTileSet);
        }

        public static void Update(GameTime gameTime)
        {
            if (!StateManager.GamePaused)
            {
                if (ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
                {
                    StateManager.GameState = StateManager.GameStates.RPG;
                    RPGManager.Activate();
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
