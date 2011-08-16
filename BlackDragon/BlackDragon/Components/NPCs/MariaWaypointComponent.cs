using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Helpers;
using BlackDragonEngine.TileEngine;
using BlackDragonEngine.Providers;
using BlackDragonEngine.Entities;
using BlackDragonEngine.Components;
using BlackDragon.Providers;

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
            return new Vector2(VariableProvider.RandomSeed.Next(0, TileMap.MapWidth), VariableProvider.RandomSeed.Next(0, TileMap.MapHeight));
        }        
    }
}
