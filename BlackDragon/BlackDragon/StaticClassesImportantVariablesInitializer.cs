using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Tile_Engine;
using BlackDragon.Providers;

namespace BlackDragon
{
    static class StaticClassesImportantVariablesInitializer
    {
        public static void InitializeImportantVariables()
        {            
            Camera.Position = Vector2.Zero;
            Camera.ViewPortWidth = 800;
            Camera.ViewPortHeight = 600;
           
        }
    }
}
