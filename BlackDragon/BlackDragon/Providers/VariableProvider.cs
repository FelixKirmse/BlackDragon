using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using BlackDragon.Entities;

namespace BlackDragon.Providers
{
    static class VariableProvider
    {
        public static Game1 Game { get; set; }
        public static Texture2D WhiteTexture { get; set; }
        public static GameObject CurrentPlayer { get; set; }
        public static GameObject Maria { get; set; }
        public static Random RandomGenerator { get; set; }
    }
}
