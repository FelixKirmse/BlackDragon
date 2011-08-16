using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using BlackDragonEngine.Providers;
using BlackDragon.Managers;

namespace BlackDragon.Managers
{
    static class GeneralInputManager
    {
        public static void HandleGeneralInput()
        {
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.MenuState = MenuStates.Ingame;
                StateManager.GamePaused = true;
                StateManager.InputLock = true;
            }
        }
    }
}
