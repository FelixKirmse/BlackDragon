using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Tile_Engine;
using BlackDragon.Providers;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon
{
    static class StaticClassesImportantVariablesInitializer
    {
        public static void InitializeImportantVariables()
        {            
            Camera.Position = Vector2.Zero;
            Camera.ViewPortWidth = 800;
            Camera.ViewPortHeight = 600;


            InputMapper.ActionKeys = new Keys[] { Keys.Enter, Keys.E };
            InputMapper.JumpKeys = new Keys[] { Keys.Space, Keys.Space };
            InputMapper.UpKeys = new Keys[] { Keys.W, Keys.Up };
            InputMapper.DownKeys = new Keys[] { Keys.S, Keys.Down };
            InputMapper.LeftKeys = new Keys[] { Keys.A, Keys.Left };
            InputMapper.RightKeys = new Keys[] { Keys.D, Keys.Right };

            VariableProvider.RandomGenerator = new Random();
        }
    }
}
