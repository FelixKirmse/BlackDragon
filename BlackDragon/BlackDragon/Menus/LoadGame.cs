﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;

namespace BlackDragon.Menus
{
    class LoadGame : Menu
    {
        private const string NYI = "Not Yet Implemented";

        public LoadGame()
        {
            menuItems.Add(new MenuItem(NYI, fontName, true));

            SetPositions();
        }

        public void Update(GameTime gameTime)
        {
            base.Update();
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.MenuState = StateManager.MenuStates.MAIN;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {
                case NYI:
                    StateManager.MenuState = StateManager.MenuStates.MAIN;
                    break;
            }
        }
    }
}