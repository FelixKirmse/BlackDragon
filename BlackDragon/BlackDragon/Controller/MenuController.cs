using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using BlackDragon.Menus;
using BlackDragon.Providers;

namespace BlackDragon.Controller
{
    static class MenuController
    {
        public static void Update(Menu menu)
        {
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.S) || ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Down))
            {
                menu.NextMenuItem();
            }

            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.W) || ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Up))
            {
                menu.PreviousMenuItem();
            }

            menu.ResolveMouseSelection();

            menu.UpdateColors();

            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Enter) || ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
            {
                menu.SelectMenuItem();
            }
        }
    }
}
