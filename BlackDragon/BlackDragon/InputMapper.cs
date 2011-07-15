using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Providers;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon
{
    static class InputMapper
    {
        public static Keys[] UpKeys = new Keys[2];
        public static Keys[] DownKeys = new Keys[2];
        public static Keys[] LeftKeys = new Keys[2];
        public static Keys[] RightKeys = new Keys[2];
        public static Keys[] JumpKeys = new Keys[2];
        public static Keys[] ActionKeys = new Keys[2];

        public static bool UP 
        {
            get
            {
                return ShortcutProvider.AreAnyKeysDown(UpKeys) || ShortcutProvider.LeftStickUp();
            }
        }

        public static bool DOWN
        {
            get
            {
                return ShortcutProvider.AreAnyKeysDown(DownKeys) || ShortcutProvider.LeftStickDown();
            }
        }

        public static bool LEFT
        {
            get
            {
                return ShortcutProvider.AreAnyKeysDown(LeftKeys) || ShortcutProvider.LeftStickLeft();
            }
        }
        public static bool RIGHT
        {
            get
            {
                return ShortcutProvider.AreAnyKeysDown(RightKeys) || ShortcutProvider.LeftStickRight();
            }
        }
        public static bool JUMP
        {
            get
            {
                return ShortcutProvider.AreAnyKeysDown(JumpKeys);
            }
        }
        public static bool ACTION
        {
            get
            {
                return ShortcutProvider.AreAnyKeysDown(ActionKeys);
            }
        }
    }    
}
