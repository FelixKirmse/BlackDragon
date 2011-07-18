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
        
        }
    }
}
