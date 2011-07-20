﻿using System;
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
            if (InputMapper.STRICTDOWN)
            {
                menu.NextMenuItem();
            }

            if (InputMapper.STRICTUP)
            {
                menu.PreviousMenuItem();
            }

            menu.ResolveMouseSelection();            

            if (InputMapper.STRICTACTION || ShortcutProvider.LeftButtonClickedNowButNotLastFrame())
            {
                menu.SelectMenuItem();
            }
        }
    }
}
