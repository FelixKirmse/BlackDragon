using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragonEngine.Entities;
using BlackDragon.Providers;
using BlackDragonEngine.TileEngine;
using BlackDragonEngine.Managers;
using BlackDragonEngine.Providers;

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

                case "PARTY":
                    GameObject memberOne = Factory.CreatePartyMember();
                    memberOne.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                    EntityManager.AddEntity(memberOne);

                    GameObject memberTwo = Factory.CreatePartyMember();
                    memberTwo.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                    EntityManager.AddEntity(memberTwo);

                    GameObject memberThree = Factory.CreatePartyMember();
                    memberThree.Position = new Vector2(x * TileMap.TileWidth, y * TileMap.TileHeight);
                    EntityManager.AddEntity(memberThree);

                    memberOne.Send("WAYPOINT_FOLLOW", VariableProvider.CurrentPlayer);
                    memberTwo.Send("WAYPOINT_FOLLOW", memberOne);
                    memberThree.Send("WAYPOINT_FOLLOW", memberTwo);
                    break;
            }
        }
    }
}
