using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xTile; 

namespace BlackDragon.Providers
{
    static class MapProvider
    {
        private static Dictionary<string, Map> maps = new Dictionary<string, Map>();

        public static void AddMap(string name, Map map)
        {
            maps.Add(name, map);            
        }

        public static Map GetMap(string name)
        {
            return maps[name];
        }
    }
}
