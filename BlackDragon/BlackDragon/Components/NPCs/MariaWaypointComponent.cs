using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Helpers;
using Tile_Engine;
using BlackDragon.Providers;
using BlackDragon.Entities;

namespace BlackDragon.Components.NPCs
{
    class MariaWaypointComponent : WaypointComponent
    {     
        public MariaWaypointComponent()
        {
            waypoints = WaypointProvider.MariaWaypoints;
            objectState = ObjectStates.IDLE;
        }    

        protected override Vector2 getNextWaypoint()
        {
            return new Vector2(VariableProvider.RandomGenerator.Next(0, TileMap.MapWidth), VariableProvider.RandomGenerator.Next(0, TileMap.MapHeight));
        }        
    }
}
