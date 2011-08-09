using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Entities;

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
