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
            
            

            LevelManager.LoadLevel("000");
            CodeManager.CheckCodes(Player);            
                        
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
                CodeManager.CheckPlayerCodes(Player);
                GeneralInputManager.HandleGeneralInput();
            }    
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            TileMap.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            #region Test
            Vector2 mouseLocation = new Vector2(InputProvider.MouseState.X, InputProvider.MouseState.Y);
            mouseLocation += Camera.Position;
            List<Vector2> path = new List<Vector2>();
            if(InputMapper.ACTION)
                path = PathFinder.FindPath(TileMap.GetCellByPixel(mouseLocation), TileMap.GetCellByPixel(Player.GetCollisionCenter(Player.PublicCollisionRectangle)));
            else
                path = PathFinder.FindReducedPath(TileMap.GetCellByPixel(mouseLocation), TileMap.GetCellByPixel(Player.GetCollisionCenter(Player.PublicCollisionRectangle)));
            if(!(path == null))
            {
                foreach (Vector2 node in path)
                {
                    spriteBatch.Draw(VariableProvider.WhiteTexture, TileMap.CellScreenRectangle(node), new Rectangle(0, 0, 16, 16), new Color(128, 0, 0, 80));
                }
            }
            #endregion
        }
    }
}
