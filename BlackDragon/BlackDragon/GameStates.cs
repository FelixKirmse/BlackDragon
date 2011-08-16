using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackDragon
{
    public enum GameStates { Title, Menu, RPG, Platform, Saving, Loading }
    public enum MenuStates { Main, LoadGame, SlotSelector, NewGame, Options, Ingame, Null }
    public enum OptionStates { Overview, Graphics, Sound, Controls, General }
    public enum PlayerStates { IDLE, ATTACKING, DAMAGED, DEAD }
    public enum PlatformStates { PLAYING, SCRIPTEDEVENT }
    public enum RPGStates { WORLDMAP, SAVEZONE, FIELD, BATTLE }

    public enum ObjectStates { Walking, Idle, Stop }
    public enum DialogueStates { Talking, Pause , Active, Inactive }
}
