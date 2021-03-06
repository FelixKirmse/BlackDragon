﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BlackDragonEngine.Providers;
using BlackDragon.Managers;
using BlackDragonEngine.Controller;
using BlackDragonEngine.Menus;

namespace BlackDragon.Menus
{
     class MainMenu : Menu
    {
         private const string newGame = "New Game";
         private const string loadGame = "Load Game";
         private const string options = "Options";
         private const string quit = "Quit";         

        public MainMenu()
        {
            menuItems.Add(new MenuItem(newGame, fontName, true));
            menuItems.Add(new MenuItem(loadGame, fontName));
            menuItems.Add(new MenuItem(options, fontName));
            menuItems.Add(new MenuItem(quit, fontName));

            SetPositions();
        }

        public override void Update()
        {
            base.Update();
            if (ShortcutProvider.KeyPressedNowButNotLastFrame(Keys.Escape))
            {
                StateManager.GameState = GameStates.Title;
            }
        }

        public override void SelectMenuItem()
        {
            string selectedItem;
            GetSelectedItem(out selectedItem);

            switch (selectedItem)
            { 
                case newGame:
                    StateManager.MenuState = MenuStates.SlotSelector;
                    MenuManager.SlotSelector.RebuildItems();
                    break;
                case loadGame:
                    StateManager.MenuState = MenuStates.LoadGame;
                    MenuManager.LoadGameMenu.RebuildItems();
                    break;
                case options:
                    StateManager.MenuState = MenuStates.Options;
                    StateManager.OptionsState = OptionStates.Overview;
                    break;
                case quit:
                    VariableProvider.Game.Exit();
                    break;
            }
        }
    }
}
