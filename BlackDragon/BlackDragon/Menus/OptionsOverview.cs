﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackDragon.Providers;
using BlackDragon.Managers;
using Microsoft.Xna.Framework.Input;
using BlackDragonEngine.Menus;
using BlackDragonEngine.Providers;

namespace BlackDragon.Menus
{
    class OptionsOverview : Menu
    {
        private const string graphicsString = "Graphics";
        private const string soundString = "Sounds";
        private const string controlString = "Controls";
        private const string generalString = "General";
        private const string backString = "Back";

        public OptionsOverview()
        {
            menuItems.Add(new MenuItem(graphicsString, fontName, true));
            menuItems.Add(new MenuItem(soundString, fontName));
            menuItems.Add(new MenuItem(controlString, fontName));
            menuItems.Add(new MenuItem(generalString, fontName));
            menuItems.Add(new MenuItem(backString, fontName));

            SetPositions();
        }

        public override void Update()
        {
            base.Update();
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                if (StateManager.GamePaused)
                    StateManager.MenuState = MenuStates.Ingame;
                else
                    StateManager.MenuState = MenuStates.Main;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {
                case generalString:
                    StateManager.OptionsState = OptionStates.General;
                    break;
                case graphicsString:
                    StateManager.OptionsState = OptionStates.Graphics;
                    break;
                case soundString:
                    StateManager.OptionsState = OptionStates.Sound;
                    break;
                case controlString:
                    StateManager.OptionsState = OptionStates.Controls;
                    break;
                case backString:
                    if (StateManager.GamePaused)
                        StateManager.MenuState = MenuStates.Ingame;
                    else
                        StateManager.MenuState = MenuStates.Main;
                    break;
            }
        }
    }
}
