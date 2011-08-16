using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Helpers;

namespace BlackDragon.Providers
{
    static class GameVariableProvider
    {
        public static SaveState SaveState;

        public static void Initialize()
        {
            SaveState = new SaveState();
        }
    }
}
