using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon
{
    public enum GameStates { TITLE, MENU, RPG, PLATFORM, SAVING, LOADING }
    public enum MenuStates { MAIN, LOADGAME, NEWGAME, OPTIONS, INGAME, NULL }
    public enum OptionStates { OVERVIEW, GRAPHICS, SOUND, CONTROL, GENERAL }
    public enum PlayerStates { IDLE, ATTACKING, DAMAGED, DEAD, DIALOG }
    public enum PlatformStates { PLAYING, DIALOG, SCRIPTEDEVENT }
    public enum RPGStates { WORLDMAP, SAVEZONE, FIELD, BATTLE }

    public enum ObjectState { WALKING, IDLE, STOP }
}
