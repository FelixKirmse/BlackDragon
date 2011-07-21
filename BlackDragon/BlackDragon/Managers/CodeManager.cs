using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Entities;
using Microsoft.Xna.Framework;
using Tile_Engine;

namespace BlackDragon.Managers
{
    static class CodeManager
    {
        public static void CheckCodes(GameObject player)
        {
            for (int y = 0; y < TileMap.MapHeight; ++y)
            {
                for (int x = 0; x < TileMap.MapWidth; ++x)
                {
                    switch (TileMap.CellCodeValue(x, y))
                    { 
                        case "START":
                            player.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight - 8);
                            break;
                    }
                }
            }
        }


        public static void CheckCodeUnderPlayer(GameObject player)
        {
            string[] codeArray = TileMap.CellCodeValue(TileMap.GetCellByPixel(player.GetCollisionCenter(player.PublicCollisionRectangle))).Split('_');

            switch (codeArray[0])
            { 
                case "TRANSITION":
                    switch (codeArray[1])
                    { 
                        case "PLATFORM":
                            StateManager.GameState = StateManager.GameStates.PLATFORM;
                            PlatformManager.Activate();
                            break;

                        case  "RPG":
                            StateManager.GameState = StateManager.GameStates.RPG;
                            RPGManager.Activate();
                            break;
                    }
                    LevelManager.LoadLevel(codeArray[2]);
                    CheckCodes(player);
                    break;

                case "PIPE":
                    if (InputMapper.STRICTDOWN)
                    {
                        StateManager.GameState = StateManager.GameStates.RPG;
                        RPGManager.Activate();
                        
                    }
                    break;
            }
        }
    }
}
