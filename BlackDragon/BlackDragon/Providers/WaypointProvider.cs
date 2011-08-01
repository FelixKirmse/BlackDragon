using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BlackDragon.Providers
{
    static class WaypointProvider
    {
        public static List<Vector2> MariaWaypoints { get; private set; }

        public static void Initialize()
        {
            #region Maria Waypoints
            MariaWaypoints = new List<Vector2>();
            MariaWaypoints.Add(new Vector2(29,26));
            MariaWaypoints.Add(new Vector2(4,8));
            MariaWaypoints.Add(new Vector2(5,18));
            MariaWaypoints.Add(new Vector2(4,33));
            MariaWaypoints.Add(new Vector2(5,31));
            MariaWaypoints.Add(new Vector2(8,26));
            MariaWaypoints.Add(new Vector2(9,11));
            MariaWaypoints.Add(new Vector2(12,27));
            MariaWaypoints.Add(new Vector2(14,30));
            MariaWaypoints.Add(new Vector2(15,14));
            MariaWaypoints.Add(new Vector2(16,5));
            MariaWaypoints.Add(new Vector2(16,35));
            MariaWaypoints.Add(new Vector2(17,26));
            MariaWaypoints.Add(new Vector2(26,5));
            MariaWaypoints.Add(new Vector2(25,29));
            MariaWaypoints.Add(new Vector2(32,4));
            MariaWaypoints.Add(new Vector2(33,34));
            MariaWaypoints.Add(new Vector2(36,20));
            MariaWaypoints.Add(new Vector2(38,13));
            MariaWaypoints.Add(new Vector2(39,23));
            MariaWaypoints.Add(new Vector2(43,12));
            MariaWaypoints.Add(new Vector2(44,26));
            MariaWaypoints.Add(new Vector2(46,3));
            #endregion
        }
    }
}
