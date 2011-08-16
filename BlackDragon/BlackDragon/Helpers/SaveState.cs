using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragonEngine.Entities;
using BlackDragonEngine.Helpers;

namespace BlackDragon.Helpers
{
    [Serializable]
    class SaveState
    {
        public string PlayerName;
        public string CurrentLevel;
        public GameStates CurrentMode;                
    }
}
