using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Entities;
using Tile_Engine;

namespace BlackDragon.Managers
{
    static class SpawnManager
    {
        public static void Spawn(string name, int x, int y)
        {
            switch (name)
            { 
                case "MARIA":   
                    GameObject maria = Factory.CreateMaria();
                    maria.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                    EntityManager.AddEntity(maria);
                    break;

                case "WATER":
                    GameObject water = Factory.CreateWater();
                    water.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                    EntityManager.AddEntity(water);
                    break;
            }
        }
    }
}
