﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using BlackDragon.Providers;
using BlackDragon.Managers;

namespace BlackDragon.Managers
{
    static class GeneralInputManager
    {
        public static void HandleGeneralInput()
        {
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.MenuState = StateManager.MenuStates.INGAME;
                StateManager.GamePaused = true;
                StateManager.InputLock = true;
            }
        }
    }
}