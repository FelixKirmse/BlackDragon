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
                StateManager.MenuState = StateManager.MenuStates.MAIN;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            {
                case generalString:
                    StateManager.OptionsState = StateManager.OptionStates.GENERAL;
                    break;
                case graphicsString:
                    StateManager.OptionsState = StateManager.OptionStates.GRAPHICS;
                    break;
                case soundString:
                    StateManager.OptionsState = StateManager.OptionStates.SOUND;
                    break;
                case controlString:
                    StateManager.OptionsState = StateManager.OptionStates.CONTROL;
                    break;
                case backString:
                    StateManager.MenuState = StateManager.MenuStates.MAIN;
                    break;
            }
        }
    }
}